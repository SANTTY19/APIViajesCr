using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class AmenidadesPorInmueble
{
    public int IdAmenidad { get; set; }

    public int IdInmueble { get; set; }

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Amenidades IdAmenidadNavigation { get; set; } = null!;

    public virtual Inmuebles IdInmuebleNavigation { get; set; } = null!;
}
