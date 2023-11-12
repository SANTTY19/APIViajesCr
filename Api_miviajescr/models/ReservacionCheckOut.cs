using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class ReservacionCheckOut
{
    public int IdReservacionCheckIn { get; set; }

    public int IdReservacion { get; set; }

    public bool UsuarioSalioDelAlojamiento { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Reservaciones IdReservacionNavigation { get; set; } = null!;
}
