using Newtonsoft.Json;
using TravelAgency.Data;

namespace TravelAgency.DataProcessor
{
    using TravelAgency.DataProcessor.ExportDtos;
    using XmlHelper;
    using Data.Models.Enums;

    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            GuideDto[] guideDtos = context.Guides
                .Where(g => g.Language.Equals(Language.Spanish))
                .OrderByDescending(g => g.TourPackagesGuides.Count)
                .ThenBy(g => g.FullName)
                .Select(g => new GuideDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                            .Select(tp => new TourPackageDto()
                            {
                                PackageName = tp.TourPackage.PackageName,
                                Description = tp.TourPackage.Description??"",
                                Price = tp.TourPackage.Price
                            })
                            .OrderByDescending(tp => tp.Price)
                            .ThenBy(tp => tp.PackageName)
                            .ToArray()

                })
                .ToArray();
            string result = xmlHelper.Serialize(guideDtos, "Guides");
            return result;
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var custromers = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .OrderByDescending(c => c.Bookings.Count(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .ThenBy(c => c.FullName)
                .Select(c => new
                {
                    c.FullName,
                    c.PhoneNumber,
                    Bookings = c.Bookings.Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd")
                        })
                        .ToArray()
                })
                .ToArray();

            string result = JsonConvert.SerializeObject(custromers, Formatting.Indented);
            return result;
        }
    }
}
