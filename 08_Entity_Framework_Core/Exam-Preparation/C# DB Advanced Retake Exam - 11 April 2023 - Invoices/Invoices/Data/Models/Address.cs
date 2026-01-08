using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 10)]
        [Unicode]
        public string StreetName { get; set; } = null!;

        public int StreetNumber { get; set; }

        [Required]
        public int PostCode { get; set; } 

        [Required]
        [StringLength(15, MinimumLength = 5)]
        [Unicode]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(15, MinimumLength = 5)]
        [Unicode]
        public string Country { get; set; } = null!;

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;

    }
}



