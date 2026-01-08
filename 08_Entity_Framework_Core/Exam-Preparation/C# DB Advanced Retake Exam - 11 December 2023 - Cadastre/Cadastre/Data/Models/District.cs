using Cadastre.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Data.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(8)]
        [RegularExpression("^[A-Z]{2}-\\d{5}$")]
        public string PostalCode { get; set; } = null!;

        [Required]
        public Region Region { get; set; }

        public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();
    }
}

