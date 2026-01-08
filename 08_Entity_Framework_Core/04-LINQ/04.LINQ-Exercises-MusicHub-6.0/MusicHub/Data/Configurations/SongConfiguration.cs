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
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> entity)
        {
            entity.HasKey(s => s.Id);

            entity.Property(s => s.Name)
            .IsRequired()
            .IsUnicode(true)
            .HasMaxLength(20);

            entity.Property(s => s.Duration)
                .IsRequired();

            entity.Property(s => s.CreatedOn)
                .IsRequired();

            entity.Property(s => s.Genre)
                .IsRequired();

            entity.Property(s => s.AlbumId)
                .IsRequired(false);

            entity.Property(s => s.WriterId)
                .IsRequired();

            //Relations in FluentAPI are described from only one of the sides.
            //It is not nessesery to describe the relations from both sides.
            //we describe them from the "One" side.
            // One to Many relation - HasOne() -> WithMany() -> HasForeignKey()
            // One to One relation - HasOne() -> WithOne() -> HasForeignKey()
            // Many to Many relation - 2x [HasOne() -> WithMany() -> HasForeignKey()]

            entity.HasOne(s => s.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.AlbumId);

            entity.HasOne(s => s.Writer)
                .WithMany(w =>  w.Songs)
                .HasForeignKey(s => s.WriterId);
        }
    }
}
