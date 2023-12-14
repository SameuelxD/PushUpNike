using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Cliente:BaseEntity
{
    public string? Nombre { get; set; }

    public int? IdDireccionFk { get; set; }

    public int? IdContactoFk { get; set; }

    public virtual Contacto? IdContactoFkNavigation { get; set; }

    public virtual Direccion? IdDireccionFkNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
