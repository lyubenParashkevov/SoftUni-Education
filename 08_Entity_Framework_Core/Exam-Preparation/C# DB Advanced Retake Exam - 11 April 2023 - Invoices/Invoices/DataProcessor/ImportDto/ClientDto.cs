using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ClientDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(25, MinimumLength = 10)]
        public string Name { get; set; } = null!;

        [XmlElement("NumberVat")]
        [Required]
        [StringLength(15, MinimumLength = 10)]
        public string NumberVat { get; set; } = null!;

        [XmlArray("Addresses")]
        public AddressDto[] Addresses { get; set; } = null!;
    }
}
