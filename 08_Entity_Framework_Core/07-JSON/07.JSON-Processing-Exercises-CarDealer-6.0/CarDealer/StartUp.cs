using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();

            dbContext.Database.Migrate();
            Console.WriteLine("Done");

            string jsonSuppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            string jsonParts = File.ReadAllText("../../../Datasets/parts.json");
            string jsonCars = File.ReadAllText("../../../Datasets/cars.json");
            string jsonCustomers = File.ReadAllText("../../../Datasets/customers.json");
            string jsonSales = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(dbContext, jsonSuppliers)); 
            //Console.WriteLine(ImportParts(dbContext, jsonParts));
            //Console.WriteLine(ImportCars(dbContext, jsonCars));
            //Console.WriteLine(ImportCustomers(dbContext, jsonCustomers)); //ok
            //Console.WriteLine(ImportSales(dbContext, jsonSales));
            //Console.WriteLine(GetOrderedCustomers(dbContext));
            //Console.WriteLine(GetCarsFromMakeToyota(dbContext));
            //Console.WriteLine(GetLocalSuppliers(dbContext));
            //Console.WriteLine(GetCarsWithTheirListOfParts(dbContext));
            Console.WriteLine(GetTotalSalesByCustomer(dbContext));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson) //9
        {
            SupplierDto[] supplierDtos = JsonConvert.DeserializeObject<SupplierDto[]>(inputJson);

            ICollection<Supplier> suppliers = new List<Supplier>();

            if (supplierDtos != null)
            {
                foreach (SupplierDto supplierDto in supplierDtos)
                {
                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = supplierDto.IsImporter
                    };

                    suppliers.Add(supplier);
                }
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson) //10
        {
            IEnumerable<PartDto> partDtos = JsonConvert.DeserializeObject<IEnumerable<PartDto>>(inputJson);

            ICollection<Part> parts = new List<Part>();

            foreach (PartDto partDto in partDtos)
            {
                ICollection<int> supplierIds = context.Suppliers
                    .Select(s => s.Id)
                    .ToList();

                if (supplierIds.Contains(partDto.SupplierId))
                {
                    Part part = new Part()
                    {
                        Name = partDto.Name,
                        Price = partDto.Price,
                        Quantity = partDto.Quantity,
                        SupplierId = partDto.SupplierId,
                    };

                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson) //11
        {

           List<CarDto> carDtos = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);
           List<Car> cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance,
                };

                foreach (var partId in carDto.PartIds.Distinct())
                {
                    car.PartsCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
            
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson) //12
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson) //13
        {
            List<SaleDto> saleDtos = JsonConvert.DeserializeObject<List<SaleDto>>(inputJson);
            List<Sale> sales = new List<Sale>();

            foreach (var saleDto in saleDtos)
            {
                Sale sale = new Sale()
                {
                    Discount = saleDto.Discount,
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                };
                sales.Add(sale);
            }

            context.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers.OrderBy(c => c.BirthDate)
                                              .ThenBy(c => c.IsYoungDriver)
                                              .AsEnumerable()
                                              .Select(c => new
                                              {
                                                  c.Name,
                                                  BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                                                  c.IsYoungDriver
                                              })
                                             .ToList();                                           
         
            string jsonResult = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return jsonResult;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars.Where(c => c.Make == "Toyota")
                                   .OrderBy(c => c.Model)
                                   .ThenByDescending(c => c.TraveledDistance)
                                   .Select(c => new
                                   {
                                       c.Id,
                                       c.Make,
                                       c.Model,
                                       c.TraveledDistance
                                   })
                                   .ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers.Where(s => !s.IsImporter)
                                             .Select(s => new
                                             {
                                                 s.Id,
                                                 s.Name,
                                                 PartsCount = s.Parts.Count,
                                             })
                                             .ToList();
            string json = JsonConvert.SerializeObject (suppliers, Formatting.Indented);
            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars.Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance,
                },
                parts = c.PartsCars.Select(pc => new
                {
                    pc.Part.Name,
                    Price = pc.Part.Price.ToString("F2"),
                })
                .ToList()
                
            })
            .ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
        .Where(c => c.Sales.Any()) // Customers with at least one sale
        .Select(c => new
        {
            c.Name,
            Sales = c.Sales.Select(s => new
            {
                CarPartsPrices = s.Car.PartsCars.Select(pc => pc.Part.Price)
            }).ToList()
        })
        .ToList() // Move to memory
        .Select(c => new
        {
            fullName = c.Name,
            boughtCars = c.Sales.Count,
            spentMoney = c.Sales.Sum(s => s.CarPartsPrices.Sum())
        })
        .OrderByDescending(c => c.spentMoney)
        .ThenByDescending(c => c.boughtCars)
        .ToList();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            string jsonResult = JsonConvert.SerializeObject(customers,Formatting.Indented, settings);

            return jsonResult;
        }



    }
}