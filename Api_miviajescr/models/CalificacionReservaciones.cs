﻿using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class CalificacionReservaciones
{
    public int IdCalificacionReserva { get; set; }

    public int IdReservacion { get; set; }

    public int IdUsuario { get; set; }

    public decimal PromedioCalificacion { get; set; }

    public string? Comentarios { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Reservaciones IdReservacionNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
