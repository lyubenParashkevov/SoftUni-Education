using Creating_DataBase_Demo.Data.Configurations;
using Creating_DataBase_Demo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating_DataBase_Demo.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
        {

        }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());    //after creating table(class in Models) and Configuratin
            modelBuilder.ApplyConfiguration(new StudentsCoursesConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Room> Rooms { get; set;}

        public DbSet<StudentsCourses> StudentsCourses { get; set; }
    }
}
