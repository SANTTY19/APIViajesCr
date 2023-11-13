﻿using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class ImagenesInmueble
{
    public int IdImagen { get; set; }

    public int IdInmueble { get; set; }

    public string? Descripcion { get; set; }

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Inmuebles IdInmuebleNavigation { get; set; } = null!;
}
