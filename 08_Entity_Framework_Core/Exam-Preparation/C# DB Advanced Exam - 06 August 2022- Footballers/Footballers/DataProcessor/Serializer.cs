namespace Footballers.DataProcessor
{
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using System.Xml;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coachesData = context.Coaches
            .Where(c => c.Footballers.Any()) // Only coaches with footballers
            .Select(c => new ExportCoachDto
            {
                Name = c.Name,
                FootballersCount = c.Footballers.Count,
                Footballers = c.Footballers
                    .OrderBy(f => f.Name) // Order footballers by Name ASC
                    .Select(f => new ExportFootballerDto
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()
                    })
                    .ToArray()
            })
            .ToArray() // EF Core bug fix - materialize before sorting
            .OrderByDescending(c => c.FootballersCount) // Order by FootballersCount DESC
            .ThenBy(c => c.Name) // Order by Name ASC
            .ToArray();

            // Serialize to XML
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCoachDto[]), new XmlRootAttribute("Coaches"));
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, coachesData, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));
            }

            return sb.ToString();
        }
        

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {


                        var teamsData = context.Teams
                    .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                    .Select(t => new
                    {
                        t.Name,
                        Footballers = t.TeamsFootballers
                            .Where(tf => tf.Footballer.ContractStartDate >= date)
                            .Select(tf => tf.Footballer)
                            .ToList() // Materialize footballers before ordering
                    })
                    .ToList(); // Materialize teams before orderi


                        var teams = teamsData
                    .Select(t => new
                    {
                        t.Name,
                        Footballers = t.Footballers
                            .OrderByDescending(f => f.ContractEndDate)
                            .ThenBy(f => f.Name)
                            .Select(f => new
                            {
                                FootballerName = f.Name,
                                ContractStartDate = f.ContractStartDate.ToString("d", CultureInfo.InvariantCulture), // Ensures "MM/dd/yyyy"
                                ContractEndDate = f.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                                BestSkillType = f.BestSkillType.ToString(),
                                PositionType = f.PositionType.ToString()
                            })
                            .ToArray()
                    })
                    .OrderByDescending(t => t.Footballers.Length) // Ordering teams based on valid footballers count
                    .ThenBy(t => t.Name)
                    .Take(5)
                    .ToArray();




            //var teams = context.Teams
            //    .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
            //    .OrderByDescending(t => t.TeamsFootballers.Count)
            //    .ThenBy(t => t.Name)
            //    .Select(t => new
            //    {
            //        t.Name,
            //        Footballers = t.TeamsFootballers.Where(tf => tf.Footballer.ContractStartDate >= date)
            //        .Where(tf => tf.Footballer.ContractStartDate >= date)
            //        .OrderByDescending(tf => tf.Footballer.ContractEndDate)
            //        .ThenBy(tf => tf.Footballer.Name)
            //        .Select(tf => new
            //        {
            //            FootballerName = tf.Footballer.Name,
            //            ContractStartDate = tf.Footballer.ContractStartDate.ToString("MM/dd/yyyy"),
            //            ContractEndDate = tf.Footballer.ContractEndDate.ToString("MM/dd/yyyy"),
            //            tf.Footballer.BestSkillType,
            //            tf.Footballer.PositionType
            //        })
            //        .ToArray()
            //    })
            //    .Take(5)
            //    .ToArray();

            string result = JsonConvert.SerializeObject(teams, Newtonsoft.Json.Formatting.Indented);
            return result;
        }
    }
}
