using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    using XmlHelper;
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder(); 
            XmlHelper xmlHelper = new XmlHelper();
            CustomerDto[] customerDtos = xmlHelper.Deserialize<CustomerDto[]>(xmlString, "Customers");

            ICollection<Customer> customersToImport = new List<Customer>();

            if(customerDtos != null)
            {
                foreach(CustomerDto customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool inValidName = customersToImport.Any(x => x.FullName.Equals(customerDto.FullName));

                    bool inValidEmail = customersToImport.Any(x => x.Email.Equals(customerDto.Email));

                    bool inValidPhone = customersToImport.Any(x => x.PhoneNumber.Equals(customerDto.PhoneNumber));  

                    if(inValidName == true || inValidEmail == true || inValidPhone == true)
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Customer customer = new Customer()
                    {
                        FullName = customerDto.FullName,
                        Email = customerDto.Email,
                        PhoneNumber = customerDto.PhoneNumber
                    };

                    customersToImport.Add(customer);
                    sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customerDto.FullName));
                }

                context.Customers.AddRange(customersToImport);
                context.SaveChanges();

            }
             return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            BookingDto[] bookingDtos = JsonConvert.DeserializeObject<BookingDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            ICollection<Booking> bookingsToImport = new List<Booking>();

            if (bookingsToImport != null)
            {

                foreach (BookingDto bookingDto in bookingDtos)
                {

                    if (!IsValid(bookingDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    bool isDateValid = DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime bookingDate);

                    if (!isDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var customer = context.Customers
                        .FirstOrDefault(c => c.FullName == bookingDto.CustomerName);

                    var tourPackage = context.TourPackages
                        .FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName);

                    if (customer != null && tourPackage != null)
                    {
                        Booking booking = new Booking()
                        {
                            BookingDate = bookingDate,
                            Customer = customer,
                            TourPackage = tourPackage

                        };

                        bookingsToImport.Add(booking);

                        sb.AppendLine(string.Format(SuccessfullyImportedBooking, booking.TourPackage.PackageName,
                                 booking.BookingDate.ToString("yyyy-MM-dd")));
                    }
                }

                context.Bookings.AddRange(bookingsToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
