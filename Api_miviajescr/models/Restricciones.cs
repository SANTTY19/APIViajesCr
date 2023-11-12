using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class Restricciones
{
    public int IdRestriccion { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }
}
