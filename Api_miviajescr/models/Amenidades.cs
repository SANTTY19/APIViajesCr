using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class Amenidades
{
    public int IdAmenidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }
}
