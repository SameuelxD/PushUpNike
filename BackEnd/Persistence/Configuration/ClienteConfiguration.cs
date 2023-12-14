using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("cliente");

            builder.HasIndex(e => e.IdContactoFk, "IdContactoFk");

            builder.HasIndex(e => e.IdDireccionFk, "IdDireccionFk");

            builder.Property(e => e.Nombre).HasMaxLength(50);

            builder.HasOne(d => d.IdContactoFkNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdContactoFk)
                .HasConstraintName("cliente_ibfk_2");

            builder.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdDireccionFk)
                .HasConstraintName("cliente_ibfk_1");
        }
    }
}