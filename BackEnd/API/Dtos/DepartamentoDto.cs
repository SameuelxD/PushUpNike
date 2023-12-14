using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class DepartamentoDto
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int? IdPaisFk { get; set; }

        public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

        public virtual Pai? IdPaisFkNavigation { get; set; }
    }
}
