using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class CiudadDto
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int? IdDepartamentoFk { get; set; }

        public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

        public virtual Departamento? IdDepartamentoFkNavigation { get; set; }
    }
}