using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating_DataBase_Demo.Data.Models
{
    [Table("Courses", Schema = "uni")]
    public class Course                        //created with DataAnotations
    {        
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode]
        [Comment("Course name")]
        public string CourseName { get; set; } = string.Empty;

        [Required]
        public DateTime  CourseStart { get; set; }

        public DateTime? CourseEnd { get; set; }

        IList<StudentsCourses> Students { get; set; } = new List<StudentsCourses>(); //for many to many requred two celections in both classes and a mapping table
    }
}
