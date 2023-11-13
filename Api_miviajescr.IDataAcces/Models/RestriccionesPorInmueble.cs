using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class RestriccionesPorInmueble
{
    public int IdRestriccion { get; set; }

    public int IdInmueble { get; set; }

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Inmuebles IdInmuebleNavigation { get; set; } = null!;

    public virtual Restricciones IdRestriccionNavigation { get; set; } = null!;
}
