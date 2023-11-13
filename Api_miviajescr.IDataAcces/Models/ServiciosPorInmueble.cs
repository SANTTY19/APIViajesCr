using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class ServiciosPorInmueble
{
    public int IdServicio { get; set; }

    public int IdInmuebles { get; set; }

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Inmuebles IdInmueblesNavigation { get; set; } = null!;

    public virtual Servicios IdServicioNavigation { get; set; } = null!;
}
