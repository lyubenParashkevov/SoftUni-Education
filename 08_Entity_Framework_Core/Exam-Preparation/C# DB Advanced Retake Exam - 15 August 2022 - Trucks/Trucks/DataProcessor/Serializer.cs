namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.XmlHelper;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportDespatcherDto[] despatcherDtos = context.Despatchers
                .Where(d => d.Trucks.Count > 0)
                .Select(d => new ExportDespatcherDto()
                {
                    DespatcherName = d.Name,
                    Trucks = d.Trucks
                              .Select(t => new ExportTruckDto()
                              {
                                  RegistrationNumber = t.RegistrationNumber,
                                  Make = t.MakeType.ToString()
                              })
                              .OrderBy(t => t.RegistrationNumber)
                              .ToArray(),
                    TrucksCount = d.Trucks.Count
                })
                .OrderByDescending(d => d.Trucks.Length)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            string result = xmlHelper.Serialize(despatcherDtos, "Despatchers");
            return result;
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients.Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                    .Select(c => new
                    {
                        c.Name,
                        Trucks = c.ClientsTrucks
                                   .Where(ct => ct.Truck.TankCapacity >= capacity)
                                   .Select(ct => new
                                   {
                                       TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                                       VinNumber = ct.Truck.VinNumber,
                                       TankCapacity = ct.Truck.TankCapacity,
                                       CargoCapacity = ct.Truck.CargoCapacity,
                                       CategoryType = ct.Truck.CategoryType,
                                       MakeType = ct.Truck.MakeType
                                   })
                                   .ToList()
                    })
                    .ToArray()
                    .Select(c => new {
                                c.Name,
                                Trucks = c.Trucks
                               .OrderBy(t => t.MakeType.ToString())   // Convert enum to string **after** data is in memory
                               .ThenByDescending(t => t.CargoCapacity)
                               .Select(t => new
                               {
                                   t.TruckRegistrationNumber,
                                   t.VinNumber,
                                   t.TankCapacity,
                                   t.CargoCapacity,
                                   CategoryType = t.CategoryType.ToString(), // Convert enum to string here
                                   MakeType = t.MakeType.ToString()         // Convert enum to string here
                               })
                               .ToArray()
                    })
                    .OrderByDescending(c => c.Trucks.Length)
                    .ThenBy(c => c.Name)
                    .Take(10)
                    .ToArray();

            string result = JsonConvert.SerializeObject(clients, Formatting.Indented);
            return result;
                                         
        }
    }
}
