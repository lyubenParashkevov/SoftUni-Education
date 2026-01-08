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
    public class SongPerformerEntityConfiguration : IEntityTypeConfiguration<SongPerformer>
    {
        public void Configure(EntityTypeBuilder<SongPerformer> entity)
        {
            entity.HasKey(sp => new { sp.SongId, sp.PerformerId });

            entity.Property(sp => sp.SongId)
                .IsRequired();

            entity.Property(sp => sp.PerformerId)
                .IsRequired();

            //2x One to Many = Many to Many Relation
            entity.HasOne(sp => sp.Song)
                .WithMany(s => s.SongPerformers)
                .HasForeignKey(sp => sp.SongId);

            entity.HasOne(sp => sp.Performer)
                .WithMany(p => p.PerformerSongs)
                .HasForeignKey(sp => sp.PerformerId);
        }
    }
}
