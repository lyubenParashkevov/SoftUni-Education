using Medicines.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportMedicineDto
    {
        [Required]
        [StringLength(150, MinimumLength = 3)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("category")]
        public int Category { get; set; }


        [Range(0.01, 1000.00)]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        [XmlElement("ProductionDate")]
        public string ProductionDate { get; set; } = null!;

        [XmlElement("ExpiryDate")]
        public string ExpiryDate { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [XmlElement("Producer")]
        public string Producer { get; set; } = null!;
    }
}
