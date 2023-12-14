using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pedido:BaseEntity
{
    public DateTime? FechaPedido { get; set; }

    public int? IdClienteFk { get; set; }

    public int? IdProductoFk { get; set; }

    public int? IdDetallePedidoFk { get; set; }

    public int? IdEstadoPedidoFk { get; set; }

    public virtual Cliente? IdClienteFkNavigation { get; set; }

    public virtual Detallepedido? IdDetallePedidoFkNavigation { get; set; }

    public virtual Estadopedido? IdEstadoPedidoFkNavigation { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
