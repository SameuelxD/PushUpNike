using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Direccion:BaseEntity
{
    public string LineaDireccion1 { get; set; } = null!;

    public string? LineaDireccion2 { get; set; }

    public string? CodigoPostal { get; set; }

    public int? IdCiudadFk { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Ciudad? IdCiudadFkNavigation { get; set; }
}
