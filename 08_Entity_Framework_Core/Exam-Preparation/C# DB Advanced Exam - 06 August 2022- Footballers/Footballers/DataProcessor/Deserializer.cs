namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.Data.XmlHelper;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCoachDto[] importCoachDtos = xmlHelper.Deserialize<ImportCoachDto[]>(xmlString, "Coaches");

            ICollection<Coach> coachesToImport = new List<Coach>();

            if (importCoachDtos != null)
            {
                foreach (ImportCoachDto importCoachDto in importCoachDtos)
                {
                    if (!IsValid(importCoachDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ICollection<Footballer> footballersToImport = new List<Footballer>();

                    foreach (ImportFootballerDto importFootballerDto in importCoachDto.Footballers)
                    {
                        if (!IsValid(importFootballerDto))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isContractStartDateValid = DateTime.TryParseExact(importFootballerDto.ContractStartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractStart);

                        bool isContractEndDateValid = DateTime.TryParseExact(importFootballerDto.ContractEndDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime contractEnd);

                        if (!isContractStartDateValid || !isContractEndDateValid
                            || contractStart > contractEnd)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isBestSkillType = Enum
                        .TryParse<BestSkillType>(importFootballerDto.BestSkillType, out BestSkillType bestSkillType);

                        bool isPositionType = Enum
                        .TryParse<PositionType>(importFootballerDto.PositionType, out PositionType positionType);

                        if(!isBestSkillType && !isPositionType)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Footballer footballer = new Footballer()
                        {
                            Name = importFootballerDto.Name,
                            ContractStartDate = contractStart,
                            ContractEndDate = contractEnd,
                            BestSkillType = bestSkillType,
                            PositionType = positionType
                        };

                        footballersToImport.Add(footballer);
                    }

                    Coach coachToImport = new Coach()
                    {
                        Name = importCoachDto.Name,
                        Nationality = importCoachDto.Nationality,
                        Footballers = footballersToImport
                    };
                    coachesToImport.Add(coachToImport);
                    sb.AppendLine(string.Format(SuccessfullyImportedCoach, coachToImport.Name, footballersToImport.Count));

                }

                context.Coaches.AddRange(coachesToImport);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();
        }







        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTeamDto[] importTeamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            List<Team> teamsToImport = new List<Team>();

            foreach (var importTeamDto in importTeamDtos)
            {             
                if (!IsValid(importTeamDto) || importTeamDto.Trophies <= 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }
              
                var uniqueFootballerIds = importTeamDto.Footballers.Distinct().ToList();
                List<Footballer> footballersToAdd = new List<Footballer>();

                foreach (var footballerId in uniqueFootballerIds)
                {
                    var footballer = context.Footballers.FirstOrDefault(f => f.Id == footballerId);

                    if (footballer == null)  
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    footballersToAdd.Add(footballer);
                }

                //if (footballersToAdd.Count == 0)
                //{
                //    sb.AppendLine("Invalid data!");
                //    continue;
                //}
           
                Team team = new Team()
                {
                    Name = importTeamDto.Name,
                    Nationality = importTeamDto.Nationality,
                    Trophies = importTeamDto.Trophies,
                    TeamsFootballers = footballersToAdd.Select(f => new TeamFootballer { Footballer = f }).ToList()
                };

                teamsToImport.Add(team);
                sb.AppendLine($"Successfully imported team - {team.Name} with {footballersToAdd.Count} footballers.");
            }

            // ✅ Save to Database
            context.Teams.AddRange(teamsToImport);
            context.SaveChanges();

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
