using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class CaracteristicasInmuebles
{
    public int IdCaracteristica { get; set; }

    public int IdInmueble { get; set; }

    public string? Descripcion { get; set; }

    public virtual Inmuebles IdInmuebleNavigation { get; set; } = null!;
}
