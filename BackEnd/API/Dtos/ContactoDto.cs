using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ContactoDto
    {
        public int Id { get; set; }

        public int Telefono { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}