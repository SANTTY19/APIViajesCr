using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class TipoUsuarios
{
    public int IdTipoUsuario { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

   
}
