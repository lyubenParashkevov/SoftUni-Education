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
    public class PerformerEntityConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> entity)
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(20);


        }
    }
}
