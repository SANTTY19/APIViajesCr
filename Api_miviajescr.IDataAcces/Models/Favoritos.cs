using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class Favoritos
{
    public int IdFavorito { get; set; }

    public int IdInmueble { get; set; }

    public int IdUsuario { get; set; }

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Inmuebles IdInmuebleNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
