using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class DisponibilidadInmuebles
{
    public int IdDisponibilidad { get; set; }

    public int IdInmueble { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public DateTime FechaCreacion { get; set; }

}
