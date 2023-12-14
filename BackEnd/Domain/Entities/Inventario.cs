using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Inventario:BaseEntity
{
    public int CantidadAlmacenada { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
