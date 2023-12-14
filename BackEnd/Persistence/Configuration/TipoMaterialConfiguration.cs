using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class TipoMaterialConfiguration : IEntityTypeConfiguration<Tipomaterial>
    {
        public void Configure(EntityTypeBuilder<Tipomaterial> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("tipomaterial");

            builder.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            builder.Property(e => e.Descripcion).HasMaxLength(50);
            builder.Property(e => e.Nombre).HasMaxLength(20);
        }
    }
}