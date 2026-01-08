using Microsoft.EntityFrameworkCore;
using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.DataProcessor.ImportDtos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            const string xmlRootName = "Households";

            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();

            HouseholdDto[]? houseDtos = xmlHelper
                .Deserialize<HouseholdDto[]>(xmlString, xmlRootName);
            if (houseDtos != null && houseDtos.Length > 0)
            {
                ICollection<Household> validHouseholds = new List<Household>();
                foreach (HouseholdDto houseDto in houseDtos)
                {
                    if (!IsValid(houseDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isAlreadyImportHousehold = context
                        .Households
                        .Any(h => h.ContactPerson == houseDto.ContactPerson ||
                                  h.Email == houseDto.Email ||
                                  h.PhoneNumber == houseDto.PhoneNumber);
                    bool isToBeImportedHousehold = validHouseholds
                        .Any(h => h.ContactPerson == houseDto.ContactPerson ||
                                  h.Email == houseDto.Email ||
                                  h.PhoneNumber == houseDto.PhoneNumber);
                    if (isAlreadyImportHousehold || isToBeImportedHousehold)
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Household houseHold = new Household()
                    {
                        ContactPerson = houseDto.ContactPerson,
                        Email = houseDto.Email,
                        PhoneNumber = houseDto.PhoneNumber,
                    };
                    validHouseholds.Add(houseHold);

                    string successMessage = string
                        .Format(SuccessfullyImportedHousehold, houseDto.ContactPerson);
                    sb.AppendLine(successMessage);
                }

                context.Households.AddRange(validHouseholds); // Faster than calling multiple .Add()
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            

            ExpensesDto[]? expenseDtos = JsonConvert
                .DeserializeObject<ExpensesDto[]>(jsonString);
            if (expenseDtos != null && expenseDtos.Length > 0)
            {
                ICollection<Expense> validExpenses = new List<Expense>();
                foreach (ExpensesDto expenseDto in expenseDtos)
                {
                    if (!IsValid(expenseDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool householdExists = context
                        .Households
                        .Any(h => h.Id == expenseDto.HouseholdId);
                    bool serviceExists = context
                        .Services
                        .Any(s => s.Id == expenseDto.ServiceId);
                    if ((!householdExists) || (!serviceExists))
                    {

                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDueDateValid = DateTime
                        .TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out DateTime dueDate);

                    bool isPaymentStatusValid = Enum
                        .TryParse<PaymentStatus>(expenseDto.PaymentStatus, out PaymentStatus paymentStatus);
                    if ((!isDueDateValid) || (!isPaymentStatusValid))
                    {

                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Expense expense = new Expense()
                    {
                        ExpenseName = expenseDto.ExpenseName,
                        Amount = expenseDto.Amount,
                        DueDate = dueDate,
                        PaymentStatus = paymentStatus,
                        HouseholdId = expenseDto.HouseholdId,
                        ServiceId = expenseDto.ServiceId,
                    };
                    validExpenses.Add(expense);

                    string successMessage = string
                        .Format(SuccessfullyImportedExpense, expenseDto.ExpenseName, expenseDto.Amount.ToString("F2"));

                    sb.AppendLine(successMessage);
                }

                context.Expenses.AddRange(validExpenses);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();
        }


        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
