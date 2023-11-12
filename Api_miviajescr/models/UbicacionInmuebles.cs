using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class UbicacionInmuebles
{
    public int IdUbicacion { get; set; }

    public int IdInmueble { get; set; }

    public string Provincia { get; set; } = null!;

    public string Canton { get; set; } = null!;

    public string Distrito { get; set; } = null!;

    public string? UbicacionDetalles { get; set; }

    public virtual Inmuebles IdInmuebleNavigation { get; set; } = null!;
}
