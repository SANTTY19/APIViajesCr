using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class Denuncias
{
    public int IdDenuncia { get; set; }

    public int IdReservacion { get; set; }

    public int IdUsuario { get; set; }

    public int IdStatusDenuncia { get; set; }

    public string Denuncia { get; set; } = null!;

    public string? Solucion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Reservaciones IdReservacionNavigation { get; set; } = null!;

    public virtual StatusDenuncia IdStatusDenunciaNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
}
