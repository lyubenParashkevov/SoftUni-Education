using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();
            //dbContext.Database.Migrate();

            //Console.WriteLine("Database migrated to the latest version successfully!");

            string xmlSuppliers = File.ReadAllText("../../../Datasets/suppliers.xml");
            string xmlPrts = File.ReadAllText("../../../Datasets/parts.xml");
            string xmlCars = File.ReadAllText("../../../Datasets/cars.xml");
            string xmlCustomers = File.ReadAllText("../../../Datasets/customers.xml");
            string xmlSales = File.ReadAllText("../../../Datasets/sales.xml");

            //Console.WriteLine(ImportSuppliers(dbContext, xmlSuppliers));
            Console.WriteLine(ImportParts(dbContext, xmlPrts));
            //Console.WriteLine(ImportCars(dbContext, xmlCars));
            //Console.WriteLine(ImportCustomers(dbContext, xmlCustomers));
            //Console.WriteLine(ImportSales(dbContext, xmlSales));
            //Console.WriteLine(GetCarsWithDistance(dbContext));
            //Console.WriteLine(GetCarsFromMakeBmw(dbContext));
            //Console.WriteLine(GetLocalSuppliers(dbContext));
            //Console.WriteLine(GetCarsWithTheirListOfParts(dbContext));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            SupplierDto[] supplierDtos = XmlHelper.Deserialize<SupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> suppliers = new List<Supplier>();

            if (supplierDtos != null)
            {
                foreach (SupplierDto supplierDto in supplierDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }

                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = supplierDto.IsImporter
                    };
                    suppliers.Add(supplier);
                }

                context.Suppliers.AddRange(suppliers);
                //context.SaveChanges();
            }
            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            PartDto[] partDtos = XmlHelper.Deserialize<PartDto[]>(inputXml, "Parts");
            ICollection<Part> parts = new List<Part>();

            if (partDtos != null)
            {
                foreach (var partDto in partDtos)
                {
                    ICollection<int> supliersIds = context.Suppliers
                        .Select(x => x.Id)
                        .ToList();

                    if (supliersIds.Contains(partDto.SupplierId))
                    {
                        Part part = new Part()
                        {
                            Name = partDto.Name,
                            Price = partDto.Price,
                            Quantity = partDto.Quantity,
                            SupplierId = partDto.SupplierId
                        };

                        parts.Add(part);
                    }
                }

                context.Parts.AddRange(parts);
                //context.SaveChanges();
            }
            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            CarDto[] carDtos = XmlHelper.Deserialize<CarDto[]>(inputXml, "Cars");

            ICollection<Car> cars = new List<Car>();
            if (carDtos != null)
            {
                foreach (var carDto in carDtos)
                {
                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = carDto.TraveledDistance
                    };

                    //foreach (var partId in carDto.PartIds.Distinct())
                    //{
                    //    car.PartsCars.Add(new PartCar
                    //    {
                    //        PartId = partId
                    //    });
                    //}

                    //cars.Add(car);

                    if (carDto.Parts != null)
                    {
                        int[] partIds = carDto
                            .Parts
                            .Where(p => IsValid(p) &&
                                        int.TryParse(p.Id, out int dummy))
                            .Select(p => int.Parse(p.Id))
                            .Distinct()
                            .ToArray();

                        foreach (int partId in partIds)
                        {
                            PartCar partCar = new PartCar()
                            {
                                PartId = partId,
                                Car = car
                            };
                            car.PartsCars.Add(partCar);
                        }

                        cars.Add(car);
                    }
                }

                context.Cars.AddRange(cars);
                context.SaveChanges();
            }

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            CustomerDto[] customerDtos = XmlHelper.Deserialize<CustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> customers = new List<Customer>();

            if (customerDtos != null)
            {
                foreach (var customerDto in customerDtos)
                {
                    Customer customer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = customerDto.BirthDate,
                        IsYoungDriver = customerDto.IsYoungDriver,
                    };
                    customers.Add(customer);
                }

                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            SaleDto[] saleDtos = XmlHelper.Deserialize<SaleDto[]>(inputXml, "Sales");

            ICollection<Sale> sales = new List<Sale>();

            ICollection<int> carIds = context.Cars.Select(c => c.Id).ToList();

            if (saleDtos != null)
            {
                foreach (var saleDto in saleDtos)
                {
                    if (carIds.Contains(saleDto.CarId))
                    {
                        Sale sale = new Sale()
                        {
                            Discount = saleDto.Discount,
                            CarId = saleDto.CarId,
                            CustomerId = saleDto.CustomerId,
                        };

                        sales.Add(sale);
                    }

                }
                context.AddRange(sales);
                context.SaveChanges();
            }

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            CarsWithDistanceDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .Select(c => new CarsWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            return XmlHelper.Serialize(cars, "cars");

        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            CarsBmwDto[] cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new CarsBmwDto()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })

                .ToArray();

            return XmlHelper.Serialize(cars, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            LocalSuppliersDto[] suppliers = context.Suppliers
                .Where(s => !(s.IsImporter))
                .Select(s => new LocalSuppliersDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return XmlHelper.Serialize(suppliers, "suppliers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            CarsWithTheirPartsDto[] cars = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Select(c => new CarsWithTheirPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                        .Select(pc => pc.Part)
                        .OrderByDescending(p => p.Price)
                        .Select(p => new PartForCarDto()
                        {
                            Name = p.Name,
                            Price = p.Price,
                        })
                        .ToArray()
                                  
                })
                .Take(5)
                .ToArray();

            return XmlHelper.Serialize(cars, "cars");
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