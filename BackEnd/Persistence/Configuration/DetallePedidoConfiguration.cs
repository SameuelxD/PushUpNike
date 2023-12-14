using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<Detallepedido>
    {
        public void Configure(EntityTypeBuilder<Detallepedido> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("detallepedido");
        }
    }
}