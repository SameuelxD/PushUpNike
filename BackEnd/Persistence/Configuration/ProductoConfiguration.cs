using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("producto");

            builder.HasIndex(e => e.IdCategoriaFk, "IdCategoriaFk");

            builder.HasIndex(e => e.IdColorFk, "IdColorFk");

            builder.HasIndex(e => e.IdInventarioFk, "IdInventarioFk");

            builder.HasIndex(e => e.IdTipoMaterialFk, "IdTipoMaterialFk");

            builder.HasIndex(e => e.IdTipoProductoFk, "IdTipoProductoFk");

            builder.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            builder.Property(e => e.Descripcion).HasMaxLength(50);
            builder.Property(e => e.Nombre).HasMaxLength(20);

            builder.HasOne(d => d.IdCategoriaFkNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoriaFk)
                .HasConstraintName("producto_ibfk_1");

            builder.HasOne(d => d.IdColorFkNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdColorFk)
                .HasConstraintName("producto_ibfk_3");

            builder.HasOne(d => d.IdInventarioFkNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdInventarioFk)
                .HasConstraintName("producto_ibfk_5");

            builder.HasOne(d => d.IdTipoMaterialFkNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdTipoMaterialFk)
                .HasConstraintName("producto_ibfk_4");

            builder.HasOne(d => d.IdTipoProductoFkNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdTipoProductoFk)
                .HasConstraintName("producto_ibfk_2");
        }
    }
}