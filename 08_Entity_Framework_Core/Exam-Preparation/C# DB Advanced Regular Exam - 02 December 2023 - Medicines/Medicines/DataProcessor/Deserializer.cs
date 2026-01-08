namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.Data.XmlHelper;
    using Medicines.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var patientsToImport = new List<Patient>();

            var patientDtos = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            foreach (var patientDto in patientDtos)
            {
                // Validate FullName
                if (!IsValid(patientDto) || string.IsNullOrEmpty(patientDto.FullName)
                    || patientDto.FullName.Length > 100 || patientDto.FullName.Length < 5)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // Validate AgeGroup and Gender
                if (!Enum.IsDefined(typeof(AgeGroup), patientDto.AgeGroup) ||
                    !Enum.IsDefined(typeof(Gender), patientDto.Gender))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // Remove duplicate medicine IDs
                var uniqueMedicineIds = patientDto.Medicines.Distinct().ToList();

                // Check if all medicine IDs exist in the database
                var validMedicineIds = context.Medicines
                    .Where(m => uniqueMedicineIds.Contains(m.Id))
                    .Select(m => m.Id)
                    .ToList();

                // If some medicines do not exist, append error message
                if (validMedicineIds.Count != uniqueMedicineIds.Count)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                // Create new Patient entity
                var patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender,
                    PatientsMedicines = validMedicineIds
                        .Select(medId => new PatientMedicine { MedicineId = medId })
                        .ToList()
                };

                patientsToImport.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName,validMedicineIds.Count));
            }

            // Save valid patients to the database
            context.Patients.AddRange(patientsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            ICollection<Pharmacy> pharmaciesToImport = new List<Pharmacy>();

            ImportPharmacyDto[] importPharmacyDtos = xmlHelper.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            if (importPharmacyDtos != null)
            {

                foreach (var pharmacyDto in importPharmacyDtos)
                {
                    // Validate pharmacy name
                    if (!IsValid(pharmacyDto) || string.IsNullOrWhiteSpace(pharmacyDto.Name))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    // Validate phone number using regex
                    Regex phoneRegex = new Regex(@"^\(\d{3}\) \d{3}-\d{4}$");
                    if (!phoneRegex.IsMatch(pharmacyDto.PhoneNumber))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    // Validate non-stop boolean (only "true" or "false" allowed)
                    if (!bool.TryParse(pharmacyDto.NonStop, out bool isNonStop))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    List<Medicine> medicinesToAdd = new List<Medicine>();

                    foreach (var medicineDto in pharmacyDto.Medicines)
                    {
                        if (!IsValid(medicineDto))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                        // Validate price
                        if (medicineDto.Price <= 0)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        // Validate producer
                        if (string.IsNullOrWhiteSpace(medicineDto.Producer))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        // Validate category
                        if (!Enum.IsDefined(typeof(Category), medicineDto.Category))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

              
                        DateTime productionDate, expiryDate;
                        bool isValidProductionDate = DateTime.TryParseExact(
                            medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out productionDate);
                        bool isValidExpiryDate = DateTime.TryParseExact(
                            medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out expiryDate);

                        if (!isValidProductionDate || !isValidExpiryDate || productionDate >= expiryDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (medicinesToAdd.Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Medicine medicine = new Medicine()
                        {
                            Name = medicineDto.Name,
                            Price = medicineDto.Price,
                            ProductionDate = productionDate,
                            ExpiryDate = expiryDate,
                            Producer = medicineDto.Producer,
                            Category = (Category)medicineDto.Category
                        };

                        medicinesToAdd.Add(medicine);
                    }
                    
                    Pharmacy pharmacy = new Pharmacy()
                    {
                        Name = pharmacyDto.Name,
                        PhoneNumber = pharmacyDto.PhoneNumber,
                        IsNonStop = isNonStop,
                        Medicines = medicinesToAdd
                    };

                    pharmaciesToImport.Add(pharmacy);
                    sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
                }
                
                context.Pharmacies.AddRange(pharmaciesToImport);
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
