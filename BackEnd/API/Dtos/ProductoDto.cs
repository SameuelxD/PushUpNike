using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public double? PrecioUnd { get; set; }

        public int? CantidadVendida { get; set; }

        public int? IdCategoriaFk { get; set; }

        public int? IdTipoProductoFk { get; set; }

        public int? IdColorFk { get; set; }

        public int? IdTipoMaterialFk { get; set; }

        public int? IdInventarioFk { get; set; }

        public virtual Categorium? IdCategoriaFkNavigation { get; set; }

        public virtual Color? IdColorFkNavigation { get; set; }

        public virtual Inventario? IdInventarioFkNavigation { get; set; }

        public virtual Tipomaterial? IdTipoMaterialFkNavigation { get; set; }

        public virtual Tipoproducto? IdTipoProductoFkNavigation { get; set; }
    }
}