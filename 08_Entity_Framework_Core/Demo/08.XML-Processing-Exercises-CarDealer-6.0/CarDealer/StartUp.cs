using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext db = new CarDealerContext();
            db.Database.Migrate();
            string path = File.ReadAllText("../../../Datasets/cars.xml");

            Console.WriteLine(ImportCars(db, path));


        }


        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {

            ImportSupplierDto[]? importSupplierDtos = XmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");
            ICollection<Supplier> suppliersToImport = new List<Supplier>();

            if (importSupplierDtos != null)
            {

                foreach (var supplier in importSupplierDtos)
                {
                    if (!IsValid(supplier))
                    {
                        continue;
                    }

                    bool isImporterDto = bool.TryParse(supplier.IsImporter, out bool isImporter);
                    if (!isImporterDto)
                    {
                        continue;
                    }

                    Supplier supplierToAdd = new Supplier()
                    {
                        Name = supplier.Name,
                        IsImporter = isImporter,
                    };

                    suppliersToImport.Add(supplierToAdd);

                }

                context.Suppliers.AddRange(suppliersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {suppliersToImport.Count}";

        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            ImportPartDto[]? importPartDtos = XmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");
            ICollection<Part> partsToImport = new List<Part>();

            if (importPartDtos != null)
            {
                foreach (var partDto in importPartDtos)
                {
                    ICollection<int> validSupplierIds = context.Suppliers
                            .Select(x => x.Id)
                            .ToList();

                    if (!IsValid(partDto))
                    {
                        continue;
                    }

                    bool isValidPrice = decimal.TryParse(partDto.Price, out decimal parsedPrice);
                    bool isValidQuantity = int.TryParse(partDto.Quantity, out int parsedQuantity);
                    bool isValidSupplierId = int.TryParse(partDto.SupplierId, out int parsedSupplierId);

                    if (!isValidPrice || !isValidQuantity || !isValidSupplierId)
                    {
                        continue;
                    }

                    if (validSupplierIds.Contains(parsedSupplierId))
                    {
                        Part part = new Part()
                        {
                            Name = partDto.Name,
                            Price = parsedPrice,
                            Quantity = parsedQuantity,
                            SupplierId = parsedSupplierId,
                        };

                        partsToImport.Add(part);
                    }
                }

                context.Parts.AddRange(partsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {partsToImport.Count}";

        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            ImportCarDto[]? importCarDtos = XmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");
            ICollection<Car> carsToImport = new List<Car>();

            if (importCarDtos != null)
            {
                ICollection<int> dbPartIds = context.Parts
                    .Select(p => p.Id)
                    .ToList();

                foreach (var carDto in importCarDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    bool isValidTraveledDistance = int.TryParse(carDto.TraveledDistance, out var parsedTraveledDistance);
                    if (!isValidTraveledDistance)
                    {
                        continue;
                    }

                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = parsedTraveledDistance,

                    };

                    ICollection<PartCar> validCarParts = new List<PartCar>();

                    if (carDto.Parts != null)
                    {
                        int[] partIds = carDto.Parts
                            .Where(p => IsValid(p) && int.TryParse(p.Id, out int canBeParsedButNotUsed))
                            .Select(p => int.Parse(p.Id))
                            .Distinct()
                            .ToArray();

                        foreach (var partId in partIds)
                        {
                            if (!dbPartIds.Contains(partId))
                            {
                                continue;
                            }
                            PartCar partCar = new PartCar()
                            {
                                PartId = partId
                            };
                            car.PartsCars.Add(partCar);
                        }

                    }

                    carsToImport.Add(car);

                }

                context.Cars.AddRange(carsToImport);
                context.SaveChanges();
            }
            return $"Successfully imported {carsToImport.Count}";

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