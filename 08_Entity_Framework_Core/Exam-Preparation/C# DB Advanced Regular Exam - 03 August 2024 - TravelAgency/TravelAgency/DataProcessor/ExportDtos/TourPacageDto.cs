using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("TourPackage")]
    public class TourPackageDto
    {

        [XmlElement("Name")]
        public string PackageName { get; set; } = null!;

        [XmlElement("Description")]
        public string? Description { get; set; } = null!;

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
