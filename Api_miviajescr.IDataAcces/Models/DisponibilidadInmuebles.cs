using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class DisponibilidadInmuebles
{
    public int IdDisponibilidad { get; set; }

    public int IdInmueble { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Inmuebles IdInmuebleNavigation { get; set; } = null!;
}
