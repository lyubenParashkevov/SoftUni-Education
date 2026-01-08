using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Unicode(false)]
        [MaxLength(2064)]
        [Required]
        public string Url { get; set; } = null!;  

        [Required] 
        public Enums.ResourcesTypes ResourceType { get; set; }
        //public ResourcesTypes ResourceType { get; set; }


        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }  

        public virtual Course Course { get; set; } = null!;
    }
}
