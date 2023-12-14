using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data;

public partial class NikeContext : DbContext
{

    public NikeContext(DbContextOptions<NikeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Detallepedido> Detallepedidos { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Estadopedido> Estadopedidos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Tipomaterial> Tipomaterials { get; set; }

    public virtual DbSet<Tipopago> Tipopagos { get; set; }

    public virtual DbSet<Tipoproducto> Tipoproductos { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


}

