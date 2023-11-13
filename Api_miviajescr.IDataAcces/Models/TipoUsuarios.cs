using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class TipoUsuarios
{
    public int IdTipoUsuario { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
