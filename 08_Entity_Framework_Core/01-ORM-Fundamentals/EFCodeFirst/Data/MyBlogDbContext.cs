using EFCodeFirst.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst.Data
{
    public class MyBlogDbContext : DbContext
    {
        public MyBlogDbContext()
        {

        }

        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            }
                base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Post> Posts { get; set; }
    }
}
