namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using XmlHelper;
    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Successfully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            ICollection<District> districtsToImpoirt = new List<District>();

            ImportDistrictDto[] importDistrictDtos = xmlHelper.Deserialize<ImportDistrictDto[]>(xmlDocument, "Districts");

            if (importDistrictDtos != null)
            {
                foreach (ImportDistrictDto districtDto in importDistrictDtos)
                {
                    if (!IsValid(districtDto))
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Districts.Any(d => d.Name == districtDto.Name))
                    {
                        sb.Append(ErrorMessage);
                        continue;
                    }

                    District district = new District
                    {
                        Name = districtDto.Name,
                        PostalCode = districtDto.PostalCode,
                        Region = Region.SouthWest
                    };

                    dbContext.Districts.Add(district);
                }
                dbContext.SaveChanges();

                foreach (ImportDistrictDto districtDto in importDistrictDtos)
                {
                    District district = dbContext.Districts.FirstOrDefault(d => d.Name == districtDto.Name);

                    if (district == null) continue; // Skip if the district was not saved

                    int propertiesCount = 0;

                    foreach (var propertyDto in districtDto.Properties)
                    {
                        if (!IsValid(propertyDto) ||
                            dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier || p.Address == propertyDto.Address))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        // ✅ Now the District has an ID, so we can safely assign it
                        Property property = new Property
                        {
                            PropertyIdentifier = propertyDto.PropertyIdentifier,
                            Area = propertyDto.Area,
                            Details = propertyDto.Details,
                            Address = propertyDto.Address,
                            DateOfAcquisition = DateTime.ParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            DistrictId = district.Id  // ✅ This now has a valid ID
                        };

                        dbContext.Properties.Add(property);
                        propertiesCount++;
                    }

                    if (propertiesCount > 0)
                    {
                        sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, propertiesCount));
                    }
                }

                dbContext.SaveChanges();

            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {

            StringBuilder sb = new StringBuilder();

            List<Citizen> citizensToImport = new List<Citizen>();
            List<PropertyCitizen> propertyCitizensToImport = new List<PropertyCitizen>();

            // Deserialize JSON
            ImportCitizenDto[] importCitizenDtos = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);

            // Valid marital statuses
            string[] validMaritalStatuses = { "Unmarried", "Married", "Divorced", "Widowed" };

            foreach (var citizenDto in importCitizenDtos)
            {
                // Validation: Check required fields and valid marital status
                if (!IsValid(citizenDto) || !validMaritalStatuses.Contains(citizenDto.MaritalStatus))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // Parse the BirthDate correctly
                if (!DateTime.TryParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidStatus = Enum.TryParse<MaritalStatus>( citizenDto.MaritalStatus, out MaritalStatus maritalStatus);
                // Create Citizen entity
                Citizen citizen = new Citizen
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = birthDate,
                    MaritalStatus = maritalStatus
                };

                citizensToImport.Add(citizen);
                dbContext.Citizens.Add(citizen);
                dbContext.SaveChanges();  // Ensure Citizen gets an ID before linking properties

                sb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count));

                int propertiesCount = 0;

                // Add PropertyCitizen records
                foreach (int propertyId in citizenDto.Properties)
                {
                    Property property = dbContext.Properties.Find(propertyId);
                    if (property == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    propertyCitizensToImport.Add(new PropertyCitizen
                    {
                        CitizenId = citizen.Id,
                        PropertyId = property.Id
                    });

                    propertiesCount++;
                }

            }

            // Save all PropertyCitizen mappings in bulk
            dbContext.PropertiesCitizens.AddRange(propertyCitizensToImport);
            dbContext.SaveChanges();

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
