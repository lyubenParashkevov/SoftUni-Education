namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.Data.XmlHelper;
    using Boardgames.DataProcessor.ExportDto;
    using Castle.DynamicProxy.Generators;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .OrderByDescending( c => c.Boardgames.Count)
                .ThenBy(c => c.FirstName + " " + c.LastName)
                .Select(c => new CreatorDto()
                {
                    Name = c.FirstName + " " + c.LastName,
                    Games = c.Boardgames
                            .OrderBy(c => c.Name)
                            .Select(g => new BoardgameDto()
                            {
                                Name = g.Name,
                                YearPublished = g.YearPublished
                            })
                            .ToArray(),
                    Count = c.Boardgames.Count
                })
                .ToArray();

            string result = xmlHelper.Serialize(creators, "Creators");
            return result;
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(bg => bg.Boardgame.YearPublished >= year
                        && bg.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers.Where(bg => bg.Boardgame.YearPublished >= year
                        && bg.Boardgame.Rating <= rating)
                         .Select(bg => new
                         {
                             bg.Boardgame.Name,
                             bg.Boardgame.Rating,
                             bg.Boardgame.Mechanics,
                             Category = bg.Boardgame.CategoryType.ToString()
                         })
                         .OrderByDescending(x => x.Rating)
                         .ThenBy(x => x.Name)
                         .ToArray()
                })
                .OrderByDescending(x => x.Boardgames.Length)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            string result = JsonConvert.SerializeObject(sellers, Formatting.Indented);
            return result;
        }
    }
}