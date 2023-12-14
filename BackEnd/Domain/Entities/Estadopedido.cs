using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Estadopedido:BaseEntity
{

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
