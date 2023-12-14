using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Detallepedido:BaseEntity
{

    public int? CantidadVendida { get; set; }

    public int? SubTotal { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
