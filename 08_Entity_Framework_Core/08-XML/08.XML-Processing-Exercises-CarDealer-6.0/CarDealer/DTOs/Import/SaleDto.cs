using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Sale")]
    public class SaleDto
    {
        [Required]
        [XmlElement("discount")]
        public decimal Discount { get; set; } 

        [Required]
        [XmlElement("carId")]
        public int CarId { get; set; } 

        [Required]
        [XmlElement("customerId")]
        public int CustomerId { get; set; }


    }
}
