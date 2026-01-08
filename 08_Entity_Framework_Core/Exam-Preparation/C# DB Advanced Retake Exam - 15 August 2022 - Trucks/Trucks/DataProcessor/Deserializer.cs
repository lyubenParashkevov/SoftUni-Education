namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.Data.XmlHelper;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();

            ICollection<Despatcher> despatchersToImport = new List<Despatcher>();
            DespatcherDto[] despatcherDtos = xmlHelper.Deserialize<DespatcherDto[]>(xmlString, "Despatchers");

            if (despatcherDtos != null)
            {
                foreach (var despatcherDto in despatcherDtos)
                {
                    ICollection<Truck> validTrucks = new List<Truck>();

                    if (!IsValid(despatcherDto) || string.IsNullOrWhiteSpace(despatcherDto.Position))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (despatcherDto.Trucks == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    foreach (var tr in despatcherDto.Trucks)
                    {
                        if (!IsValid(tr))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isValidCategoryType = Enum.IsDefined(typeof(CategoryType), tr.CategoryType);
                        bool isValidMakeType = Enum.IsDefined(typeof(MakeType), tr.MakeType);

                        if (!isValidCategoryType || !isValidMakeType)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }


                        Truck truck = new Truck()
                        {
                            RegistrationNumber = tr.RegistrationNumber,
                            VinNumber = tr.VinNumber,
                            TankCapacity = tr.TankCapacity,
                            CargoCapacity = tr.CargoCapacity,
                            CategoryType = (CategoryType)tr.CategoryType,
                            MakeType = (MakeType)tr.MakeType
                        };

                        validTrucks.Add(truck);
                    }

                    Despatcher despatcher = new Despatcher()
                    {
                        Name = despatcherDto.Name,
                        Position = despatcherDto.Position,
                        Trucks = validTrucks
                    };

                    despatchersToImport.Add(despatcher);
                    sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcherDto.Name, validTrucks.Count));
                }

                context.Despatchers.AddRange(despatchersToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();
            ICollection<Client> clientsToImport = new List<Client>();

            ClientDto[] clientsDto = JsonConvert.DeserializeObject<ClientDto[]>(jsonString);

            if (clientsDto != null)
            {
                foreach (ClientDto clientDto in clientsDto)
                {
                    if (!IsValid(clientDto) || clientDto.Type == "usual" || string.IsNullOrWhiteSpace(clientDto.Nationality))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                  
                    var uniqueTruckIds = clientDto.Trucks?.Distinct().ToList()?? new List<int>();

                    var existingTrucks = context.Trucks.Where(t => uniqueTruckIds.Contains(t.Id)).ToList();

                    if (existingTrucks.Count == 0) 
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    foreach (var truckId in uniqueTruckIds)
                    {
                        if (!context.Trucks.Any(t => t.Id == truckId))
                        {
                            sb.AppendLine("Invalid data!");  // ✅ Log for each invalid truck
                        }
                    }

                    Client client = new Client()
                    {
                        Name = clientDto.Name,
                        Nationality = clientDto.Nationality,
                        Type = clientDto.Type,
                       
                    };

                    context.Clients.Add(client);
                    context.SaveChanges();

                    var clientTrucks = existingTrucks.Select(truckId => new ClientTruck
                    {
                        ClientId = client.Id, // Now the Client ID exists
                        TruckId = truckId.Id
                    }).ToList();

                    context.ClientsTrucks.AddRange(clientTrucks);
                    context.SaveChanges();

                    sb.AppendLine(string.Format(SuccessfullyImportedClient, clientDto.Name, existingTrucks.Count));

                }

                context.AddRange(clientsToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}