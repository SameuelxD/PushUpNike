using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class TransaccionesConfiguration : IEntityTypeConfiguration<Transaccione>
    {
        public void Configure(EntityTypeBuilder<Transaccione> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("transacciones");

            builder.HasIndex(e => e.IdPedidoFk, "IdPedidoFk");

            builder.HasIndex(e => e.IdTipoPagoFk, "IdTipoPagoFk");

            builder.Property(e => e.FechaTransaccion).HasColumnType("datetime");

            builder.HasOne(d => d.IdPedidoFkNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdPedidoFk)
                .HasConstraintName("transacciones_ibfk_1");

            builder.HasOne(d => d.IdTipoPagoFkNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdTipoPagoFk)
                .HasConstraintName("transacciones_ibfk_2");
        }
    }
}
