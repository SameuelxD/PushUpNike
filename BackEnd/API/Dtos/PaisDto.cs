using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PaisDto
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
    }

}
