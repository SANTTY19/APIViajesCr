using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class CalificacionUsuarios
{
    public int IdCalificacionUsuario { get; set; }

    public int IdUsuarioCalificado { get; set; }

    public int IdUsuarioCalificador { get; set; }

    public decimal PromedioCalificacion { get; set; }

    public string? Comentarios { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Usuarios IdUsuarioCalificadoNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioCalificadorNavigation { get; set; } = null!;
}
