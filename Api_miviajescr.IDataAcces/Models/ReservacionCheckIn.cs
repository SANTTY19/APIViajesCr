using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class ReservacionCheckIn
{
    public int IdReservacionCheckIn { get; set; }

    public int IdReservacion { get; set; }

    public bool UsuarioLlegoAlAlojamiento { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Reservaciones IdReservacionNavigation { get; set; } = null!;
}
