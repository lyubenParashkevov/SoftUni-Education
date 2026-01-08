using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Newtonsoft.Json;
using System.Globalization;

namespace Cadastre.DataProcessor
{
    using Cadastre.DataProcessor.ExportDtos;
    using XmlHelper;
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)  //100/100
        {
            DateTime date;

            DateTime.TryParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            var properties = dbContext.Properties.Where(p => p.DateOfAcquisition >= date)
                          .OrderByDescending(p => p.DateOfAcquisition)
                          .ThenBy(p => p.PropertyIdentifier)
                          .Select(p => new
                          {
                              p.PropertyIdentifier,
                              p.Area,
                              p.Address,
                              DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                              Owners = p.PropertiesCitizens
                                        .Select(pc => new
                                        {
                                            pc.Citizen.LastName,
                                            MaritalStatus = pc.Citizen.MaritalStatus.ToString()
                                        })
                                        .OrderBy(pc => pc.LastName)
                                        .ToArray()
                          })
                         .ToArray();

            string result = JsonConvert.SerializeObject(properties, Formatting.Indented);
            return result;
        } 

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)  //100/100
        {
            XmlHelper xmlHelper = new XmlHelper();

            var properties =  dbContext.Properties
                .Where(p => p.Area >= 100)
                .OrderByDescending (p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select (p => new ExportPropDto()
                {
                   PropertyIdentifier =  p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    PostalCode = p.District.PostalCode,
                })
                .ToArray();

            string result = xmlHelper.Serialize(properties, "Properties");
            return result;
        }
    }
}
