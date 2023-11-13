using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class StatusReservacion
{
    public int IdStatusReservacion { get; set; }

    public string StatusReservacion1 { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public virtual ICollection<Reservaciones> Reservaciones { get; set; } = new List<Reservaciones>();
}
