using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(14)]
        [RegularExpression("^\\(\\d{3}\\) \\d{3}-\\d{4}$")]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; } = null!;

        [XmlAttribute("non-stop")]
        public string NonStop { get; set; } = null!;

        [XmlArray("Medicines")]
        public ImportMedicineDto[] Medicines { get; set; } = null!;
    }
}
