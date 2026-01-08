using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext db = new ProductShopContext();
            //db.Database.Migrate();

            //string jsonString = File.ReadAllText("../../../Datasets/categories-products.json");

            string result = GetUsersWithProducts(db);
            Console.WriteLine(result);

            //var cp = db.CategoriesProducts.ToList();
            //db.CategoriesProducts.RemoveRange(cp);
            //db.SaveChanges();


        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportUserDto[]? importUserDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            if (importUserDtos != null)
            {

                ICollection<User> usersToAdd = new List<User>();

                foreach (ImportUserDto impDto in importUserDtos)
                {
                    int? dtoAge = null;

                    if (!IsValid(impDto))
                    {
                        continue;
                    }

                    if (impDto != null)
                    {
                        bool age = int.TryParse(impDto.Age, out int parsedAge);

                        if (!IsValid(age))
                        {
                            continue;
                        }
                        dtoAge = parsedAge;
                    }



                    User user = new User()
                    {
                        FirstName = impDto.FirstName,
                        LastName = impDto.LastName,
                        Age = dtoAge
                    };

                    usersToAdd.Add(user);
                }

                context.AddRange(usersToAdd);

                context.SaveChanges();
                result = $"Successfully imported {usersToAdd.Count}";
            }
            return result;
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportProductDto[]? importProductDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> productsToAdd = new List<Product>();

            ICollection<int> dbUsers = context.Users
                .Select(u => u.Id)
                .ToList();

            if (importProductDtos != null)
            {

                foreach (ImportProductDto productDto in importProductDtos)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    bool isValidPrice = decimal.TryParse(productDto.Price, out decimal parsedPrice);
                    bool isValidSellerId = int.TryParse(productDto.SellerId, out int parsedSellerId);

                    if (!isValidPrice || !isValidSellerId)
                    {
                        continue;
                    }

                    int? buyerId = null;

                    if (productDto.BuyerId != null)
                    {
                        bool isValidBuyerId = int.TryParse(productDto.BuyerId, out int parsedBuyerId);

                        if (!isValidBuyerId)
                        {
                            continue;
                        }

                        if (!dbUsers.Contains(parsedBuyerId))
                        {
                            continue;
                        }
                        buyerId = parsedBuyerId;
                    }

                    if (!dbUsers.Contains(parsedSellerId))
                    {
                        continue;
                    }

                    Product product = new Product()
                    {
                        Name = productDto.Name,
                        Price = parsedPrice,
                        SellerId = parsedSellerId,
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

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCategoriesDto[]? importCategoriesDtos = JsonConvert.DeserializeObject<ImportCategoriesDto[]>(inputJson);

            ICollection<Category> categoriesToImport = new List<Category>();

            if (importCategoriesDtos != null)
            {
                foreach (ImportCategoriesDto importCategoriesDto in importCategoriesDtos)
                {
                    if (!IsValid(importCategoriesDto))
                    {
                        continue;
                    }

                    Category category = new Category()
                    {

                        Name = importCategoriesDto.Name
                    };

                    categoriesToImport.Add(category);
                }

                context.Categories.AddRange(categoriesToImport);
                context.SaveChanges();

                result = $"Successfully imported {categoriesToImport.Count}";
            }

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportCatProdDto[]? importCatProdDtos = JsonConvert.DeserializeObject<ImportCatProdDto[]>(inputJson);

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            ICollection<int> categoriesIds = context.Categories
                                                    .Select(c => c.Id)
                                                    .ToHashSet();

            ICollection<int> productsIds = context.Products
                                                  .Select(p => p.Id)
                                                  .ToHashSet();

            if (importCatProdDtos != null)
            {
                foreach (ImportCatProdDto importCatProdDto in importCatProdDtos)
                {
                    if (!IsValid(importCatProdDto))
                    {
                        continue;
                    }

                    bool isvalidCategoryId = int.TryParse(importCatProdDto.CategoryId, out int parsedCategoryId);
                    bool isValidProductId = int.TryParse(importCatProdDto.ProductId, out int parsedProductId);

                    if (!isvalidCategoryId || !isValidProductId)
                    {
                        continue;
                    }

                    if (!categoriesIds.Contains(parsedCategoryId))
                    {
                        continue;
                    }

                    if (!productsIds.Contains(parsedProductId))
                    {
                        continue;
                    }

                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = parsedCategoryId,
                        ProductId = parsedProductId,
                    };

                    categoryProducts.Add(categoryProduct);

                }

                context.CategoriesProducts.AddRange(categoryProducts);
                context.SaveChanges();
                result = $"Successfully imported {categoryProducts.Count}";
            }

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                                  .Where(p => p.Price >= 500 && p.Price <= 1000)
                                  .OrderBy(p => p.Price)
                                  .Select(p => new
                                  {
                                      p.Name,
                                      Price = Math.Round(p.Price, 2),
                                      Seller = p.Seller.FirstName + " " + p.Seller.LastName

                                  })
                                  .ToList();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonString = JsonConvert.SerializeObject(products, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            });

            return jsonString;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                                .Where(p => p.BuyerId.HasValue)
                                .Select(p => new
                                {
                                    p.Name,
                                    p.Price,
                                    BuyerFirstName = p.Buyer.FirstName,
                                    BuyerLastName = p.Buyer.LastName
                                })
                                .ToList()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();


            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            });

            return jsonString;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                             .OrderByDescending(c => c.CategoriesProducts.Count)
                             .Select(c => new
                             {
                                 Category = c.Name,
                                 ProductsCount = c.CategoriesProducts.Count,
                                 AveragePrice = c.CategoriesProducts.Average(p => p.Product.Price).ToString("F2"),
                                 TotalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("F2"),
                             })
                             .ToList();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonString = JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            });

            return jsonString;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                     .Where(u => u.ProductsSold
                     .Any(x => x.BuyerId.HasValue))
                     .Select(u => new
                     {
                         u.FirstName ,
                         u.LastName,
                         u.Age,
                         SoldProducts = new
                         {
                             Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                             Products = u.ProductsSold
                                         .Where(p => p.BuyerId.HasValue)
                                         .Select(x => new
                                         {
                                             x.Name,
                                             x.Price,
                                         })
                                         .ToList()
                         }

                     })
                     .ToList()
                     .OrderByDescending(u => u.SoldProducts.Count)
                     .ToList();

            var resultObject = new
            {
                UsersCount = users.Count,
                Users = users

            };

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string jsonString = JsonConvert.SerializeObject(resultObject, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver,
                NullValueHandling = NullValueHandling.Ignore,
            });

            return jsonString;

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