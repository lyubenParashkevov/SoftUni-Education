namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.RegularExpressions;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.Data.XmlHelper;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            ICollection<Creator> creatorsToImport = new List<Creator>();

            ImportCreatorDto[] importCreatorDtos = xmlHelper.Deserialize<ImportCreatorDto[]>(xmlString, "Creators");

            if (importCreatorDtos != null)
            {
                foreach (var creatorDto in importCreatorDtos)
                {
                    if (!IsValid(creatorDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ICollection<Boardgame> boardgamesToAdd = new List<Boardgame>();

                    var uniqueBoardgames = creatorDto.Boardgames.Distinct().ToList();

                    foreach (var boardgameDto in uniqueBoardgames)
                    {
                        if (!IsValid(boardgameDto) || string.IsNullOrEmpty(boardgameDto.Name))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;

                        }

                        bool isValidCategoty = Enum.TryParse<CategoryType>(boardgameDto.CategoryType , out CategoryType categoryType);

                        Boardgame boardgame = new Boardgame()
                        {
                            Name = boardgameDto.Name,
                            Rating = boardgameDto.Rating,
                            YearPublished = boardgameDto.YearPublished,
                            CategoryType = categoryType,
                            Mechanics = boardgameDto.Mechanics,
                        };

                        boardgamesToAdd.Add(boardgame);

                    }

                    Creator creator = new Creator()
                    {
                        FirstName = creatorDto.FirstName,
                        LastName = creatorDto.LastName,
                        Boardgames = boardgamesToAdd
                    };

                    creatorsToImport.Add(creator);
                    sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, 
                        creator.Boardgames.Count));
                }

                context.Creators.AddRange(creatorsToImport);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();

        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {

            StringBuilder sb = new StringBuilder();
            ICollection<Seller> sellersToImport = new List<Seller>();

            ImportSellerDto[] importSellerDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            if (importSellerDtos != null)
            {
                foreach (ImportSellerDto sellerDto in importSellerDtos)
                {
                    if (!IsValid(sellerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if(string.IsNullOrWhiteSpace(sellerDto.Name) ||
                            string.IsNullOrWhiteSpace(sellerDto.Address) ||
                            string.IsNullOrWhiteSpace(sellerDto.Country) ||
                            string.IsNullOrWhiteSpace(sellerDto.Website))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var uniqueGameIds = sellerDto.Boardgames.Distinct().ToList();

                    var existingBoardgames = context.Boardgames
                        .Where(b => uniqueGameIds.Contains(b.Id))
                        .ToList();

                    if (!existingBoardgames.Any())
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Seller seller = new Seller()
                    {
                        Name = sellerDto.Name,
                        Address = sellerDto.Address,
                        Country = sellerDto.Country,
                        Website = sellerDto.Website,
                        BoardgamesSellers = existingBoardgames.Select(b => new BoardgameSeller()
                        {
                            BoardgameId = b.Id
                        }).ToList()
                    };

                    sellersToImport.Add(seller);
                    sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
                }

                context.AddRange(sellersToImport);
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
