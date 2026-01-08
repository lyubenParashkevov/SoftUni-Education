using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating_DataBase_Demo.Data.Models
{
    [Table("StudentsCourses", Schema = "uni")]
    public class StudentsCourses
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = null!;
    }
}
