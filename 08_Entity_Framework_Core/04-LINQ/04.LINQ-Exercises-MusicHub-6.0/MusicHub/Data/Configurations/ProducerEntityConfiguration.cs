using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Configurations
{
    public class ProducerEntityConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode();

            entity.Property(p => p.Pseudonym)
                .IsRequired(false)
                .IsUnicode();

            entity.Property(p => p.PhoneNumber)
                .IsRequired(false)
                .IsUnicode();

            
        }
    }
}
