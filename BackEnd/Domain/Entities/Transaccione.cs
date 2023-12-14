using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Transaccione:BaseEntity
{
    public DateTime? FechaTransaccion { get; set; }

    public double? MontoTotal { get; set; }

    public int? IdPedidoFk { get; set; }

    public int? IdTipoPagoFk { get; set; }

    public virtual Pedido? IdPedidoFkNavigation { get; set; }

    public virtual Tipopago? IdTipoPagoFkNavigation { get; set; }
}
