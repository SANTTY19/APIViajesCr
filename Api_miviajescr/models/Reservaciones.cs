using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class Reservaciones
{
    public int IdReservacion { get; set; }

    public int IdInmueble { get; set; }

    public int IdUsuario { get; set; }

    public int IdStatusReservacion { get; set; }

    public DateTime FechaIngreso { get; set; }

    public DateTime FechaSalida { get; set; }

    public decimal? MontoDescuento { get; set; }

    public decimal MontoTotal { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<CalificacionReservaciones> CalificacionReservaciones { get; set; } = new List<CalificacionReservaciones>();

    public virtual ICollection<Denuncias> Denuncias { get; set; } = new List<Denuncias>();

    public virtual ICollection<HistoricoLugaresVisitados> HistoricoLugaresVisitados { get; set; } = new List<HistoricoLugaresVisitados>();

    public virtual Inmuebles IdInmuebleNavigation { get; set; } = null!;

    public virtual StatusReservacion IdStatusReservacionNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<ReservacionCheckIn> ReservacionCheckIn { get; set; } = new List<ReservacionCheckIn>();

    public virtual ICollection<ReservacionCheckOut> ReservacionCheckOut { get; set; } = new List<ReservacionCheckOut>();
}
