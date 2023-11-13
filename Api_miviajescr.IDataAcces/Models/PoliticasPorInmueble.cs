using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class PoliticasPorInmueble
{
    public int IdPolitica { get; set; }

    public int IdInmueble { get; set; }

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Inmuebles IdInmuebleNavigation { get; set; } = null!;

    public virtual Politicas IdPoliticaNavigation { get; set; } = null!;
}
