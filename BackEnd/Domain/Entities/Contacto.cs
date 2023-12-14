using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contacto:BaseEntity
{

    public int Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
