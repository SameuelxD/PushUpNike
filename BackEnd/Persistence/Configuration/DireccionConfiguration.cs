using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("direccion");

            builder.HasIndex(e => e.IdCiudadFk, "IdCiudadFk");

            builder.HasIndex(e => e.LineaDireccion1, "LineaDireccion1").IsUnique();

            builder.Property(e => e.CodigoPostal).HasMaxLength(10);
            builder.Property(e => e.LineaDireccion1).HasMaxLength(50);
            builder.Property(e => e.LineaDireccion2).HasMaxLength(50);

            builder.HasOne(d => d.IdCiudadFkNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdCiudadFk)
                .HasConstraintName("direccion_ibfk_1");
        }
    }
}