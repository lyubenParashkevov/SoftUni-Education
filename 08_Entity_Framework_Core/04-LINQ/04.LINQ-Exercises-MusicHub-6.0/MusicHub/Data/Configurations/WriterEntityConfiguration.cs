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
    public class WriterEntityConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20);

            entity.Property(x => x.Pseudonym)
                .IsRequired(false)
                .IsUnicode();

        }
    }
}
