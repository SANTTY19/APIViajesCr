using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class Inmuebles
{
    public int IdInmueble { get; set; }

    public int IdUsuario { get; set; }

    public int IdTipoInmueble { get; set; }

    public string TituloInmueble { get; set; } = null!;

    public string DescripcionInmuebles { get; set; } = null!;

    public decimal PrecioPorNoche { get; set; }

    public decimal PromedioCalificacion { get; set; }

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

}