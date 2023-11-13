using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class Servicios
{
    public int IdServicio { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }
}
