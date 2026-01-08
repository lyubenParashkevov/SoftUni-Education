using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class CustomerDto
    {
        [XmlAttribute("phoneNumber")]
        [Required]
        [StringLength(13)]
        [RegularExpression(@"\+\d{12}")]
        public string PhoneNumber { get; set; } = null!;

        [XmlElement("FullName")]
        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string FullName { get; set; } = null!;

        [XmlElement("Email")]
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Email { get; set; } = null!;
    }
}

