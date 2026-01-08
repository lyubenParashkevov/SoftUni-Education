using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType("Household")]
    public class HouseholdDto
    {
       
        [XmlElement("ContactPerson")]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string ContactPerson { get; set; } = null!;    

        [XmlElement("Email")]
        [StringLength(80, MinimumLength = 6)]
        public string? Email {  get; set; } = null!;

        [XmlAttribute("phone")]
        [Required]
        [StringLength(15)]
        [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
        public string PhoneNumber { get; set; } = null!;
    }
}
