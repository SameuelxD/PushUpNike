using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("pedido");

            builder.HasIndex(e => e.IdClienteFk, "IdClienteFk");

            builder.HasIndex(e => e.IdDetallePedidoFk, "IdDetallePedidoFk");

            builder.HasIndex(e => e.IdEstadoPedidoFk, "IdEstadoPedidoFk");

            builder.Property(e => e.FechaPedido).HasColumnType("datetime");

            builder.HasOne(d => d.IdClienteFkNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdClienteFk)
                .HasConstraintName("pedido_ibfk_1");

            builder.HasOne(d => d.IdDetallePedidoFkNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdDetallePedidoFk)
                .HasConstraintName("pedido_ibfk_2");

            builder.HasOne(d => d.IdEstadoPedidoFkNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEstadoPedidoFk)
                .HasConstraintName("pedido_ibfk_3");
        }
    }
}