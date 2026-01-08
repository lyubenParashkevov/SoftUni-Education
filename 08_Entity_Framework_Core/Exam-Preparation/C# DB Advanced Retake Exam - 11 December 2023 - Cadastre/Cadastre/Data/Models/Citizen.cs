using Cadastre.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cadastre.Data.Models
{
    public class Citizen
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; } = new HashSet<PropertyCitizen>();

    }
}

