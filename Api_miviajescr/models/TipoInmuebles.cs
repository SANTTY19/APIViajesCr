using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class TipoInmuebles
{
    public int IdTipoInmueble { get; set; }

    public string TipoInmueble { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }
}
