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
    public class AlbumEntityConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> entity)
        {
            entity.HasKey(a => a.Id);

            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode();

            entity.Property(a => a.ReleaseDate)
                .IsRequired();

            entity.Property(a => a.ProducerId)
                .IsRequired(false);

            entity.HasOne(a => a.Producer)
                .WithMany(p => p.Albums)
                .HasForeignKey(a => a.ProducerId);

        }
    }
}
