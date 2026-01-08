using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class AddressDto
    {
        [Required]
        [StringLength(20, MinimumLength = 10)]
        [Unicode]
        public string StreetName { get; set; } = null!;
        public int StreetNumber { get; set; }
        public int PostCode { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        [Unicode]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(15, MinimumLength = 5)]
        [Unicode]
        public string Country { get; set; } = null!;
    }
}

