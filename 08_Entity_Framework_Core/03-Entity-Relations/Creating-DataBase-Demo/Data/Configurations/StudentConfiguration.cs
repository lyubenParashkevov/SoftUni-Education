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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students", "uni")  // if Schema is uni, not dbo. By default is dbo type.
                .HasComment("University Students");   // this comment is optional


            builder.HasKey(p => p.StudentPk); // If name ends with "Id", it becomes PK Identity

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasComment("Student's name");  // this comment is optional

            builder.Property(p => p.FacultyNumber)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);  
        }
    }
}
