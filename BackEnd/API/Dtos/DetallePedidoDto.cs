using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class DetallePedidoDto
    {
        public int Id { get; set; }

        public int? CantidadVendida { get; set; }

        public int? SubTotal { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}