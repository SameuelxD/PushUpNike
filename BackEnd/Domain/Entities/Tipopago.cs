using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Tipopago:BaseEntity
{
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
