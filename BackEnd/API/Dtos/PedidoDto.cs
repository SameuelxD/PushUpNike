using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }

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

}