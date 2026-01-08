using Creating_DataBase_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating_DataBase_Demo.Data.Configurations
{
    public class StudentsCoursesConfiguration : IEntityTypeConfiguration<StudentsCourses>
    {
        public void Configure(EntityTypeBuilder<StudentsCourses> builder)
        {
            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
