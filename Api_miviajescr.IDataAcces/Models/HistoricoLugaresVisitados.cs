using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class HistoricoLugaresVisitados
{
    public int IdHistoricoLugarVisitado { get; set; }

    public int IdReservacion { get; set; }

    public int IdUsuario { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Reservaciones IdReservacionNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
