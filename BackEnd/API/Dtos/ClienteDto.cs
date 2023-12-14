using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int? IdDireccionFk { get; set; }

        public int? IdContactoFk { get; set; }

        public virtual Contacto? IdContactoFkNavigation { get; set; }

        public virtual Direccion? IdDireccionFkNavigation { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}