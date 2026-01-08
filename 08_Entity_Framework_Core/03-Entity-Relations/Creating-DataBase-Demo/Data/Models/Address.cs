using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating_DataBase_Demo.Data.Models
{
   
        [Table("Addresses", Schema = "uni")]
        public class Address
        {
            [Key]
            public int Id { get; set; }
            [Required]
            [MaxLength(255)]
            [Unicode]
            public string Town { get; set; } = string.Empty;

            [Required]
            [MaxLength(10)]
            [Unicode(false)]
            public string PostCode { get; set; } = string.Empty;

            [MaxLength(255)]
            [Unicode]
            public string? AddressLine { get; set; }

            public int StudentId { get; set; }

            [ForeignKey(nameof(StudentId))]
            public Student Student { get; set; } = null!;
        }
    
}
