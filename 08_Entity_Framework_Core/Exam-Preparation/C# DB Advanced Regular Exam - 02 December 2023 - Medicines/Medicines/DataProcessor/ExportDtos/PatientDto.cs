using Medicines.DataProcessor.ImportDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType("Patient")]
    public class PatientDto
    {
        [XmlAttribute("Gender")]
        public string Gender { get; set; } = null!;

        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [XmlElement("AgeGroup")]
        public string AgeGroup { get; set; } = null!;

        [XmlArray("Medicines")]
        public MedicineDto[] Medicines { get; set; } = null!;
    }
}
