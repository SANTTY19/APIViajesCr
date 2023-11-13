using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class TipoInmuebles
{
    public int IdTipoInmueble { get; set; }

    public string TipoInmueble { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Inmuebles> Inmuebles { get; set; } = new List<Inmuebles>();
}
