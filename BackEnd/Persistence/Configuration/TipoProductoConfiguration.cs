using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class TipoProductoConfiguration : IEntityTypeConfiguration<Tipoproducto>
    {
        public void Configure(EntityTypeBuilder<Tipoproducto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("tipoproducto");

            builder.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            builder.Property(e => e.Descripcion).HasMaxLength(50);
            builder.Property(e => e.Nombre).HasMaxLength(20);
        }
    }
}