using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class TransaccionesDto
    {
        public int Id { get; set; }

        public DateTime? FechaTransaccion { get; set; }

        public double? MontoTotal { get; set; }

        public int? IdPedidoFk { get; set; }

        public int? IdTipoPagoFk { get; set; }

        public virtual Pedido? IdPedidoFkNavigation { get; set; }

        public virtual Tipopago? IdTipoPagoFkNavigation { get; set; }
    }
}