namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.Data.XmlHelper;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            XmlHelper xmlHelper = new XmlHelper();

            DateTime dateTime = DateTime.Parse(date);

            var patients = context.Patients
            .Where(p => p.PatientsMedicines
                .Any(pm => pm.Medicine.ProductionDate > dateTime)) // Filter by production date
            .Select(p => new PatientDto
            {
                Name = p.FullName,
                Gender = p.Gender.ToString().ToLower(),
                AgeGroup = p.AgeGroup.ToString(),
                Medicines = p.PatientsMedicines
                    .Where(pm => pm.Medicine.ProductionDate > dateTime)
                    .OrderByDescending(pm => pm.Medicine.ExpiryDate)
                    .ThenBy(pm => pm.Medicine.Price)
                    .Select(pm => new MedicineDto
                    {
                        Name = pm.Medicine.Name,
                        Price = pm.Medicine.Price.ToString("F2", CultureInfo.InvariantCulture),
                        Category = pm.Medicine.Category.ToString().ToLower(),
                        Producer = pm.Medicine.Producer,
                        BestBefore = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                    })
                    .ToArray()
            })
            .OrderByDescending(p => p.Medicines.Length)
            .ThenBy(p => p.Name)
            .ToArray();

            string result = xmlHelper.Serialize(patients, "Patients");

            return result;
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            Category category = (Category)medicineCategory;

            var medicines = context.Medicines
                .Where(m => m.Category == category && m.Pharmacy.IsNonStop)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    m.Name,
                    Price = m.Price.ToString("F2"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber,
                    }                  

                })
                .ToArray();

            string result = JsonConvert.SerializeObject(medicines, Formatting.Indented);
            return result;
        }
    }
}
