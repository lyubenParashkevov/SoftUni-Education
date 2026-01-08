using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Customer")]
    public class CustomerDto
    {
        [Required]
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("bitrhDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
