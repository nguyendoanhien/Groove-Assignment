using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalNotesAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Configurations
{
    public class NoteMappingConfiguration : IEntityTypeConfiguration<NotesEntity>
    {
        public void Configure(EntityTypeBuilder<NotesEntity> builder)
        {
            builder.ToTable("Notes");
            builder.Property(x => x.Title).HasColumnName("Title").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(255);
        }
    }
}
