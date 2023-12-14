using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Tipoproducto:BaseEntity
{
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
