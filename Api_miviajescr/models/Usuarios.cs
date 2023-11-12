using System;
using System.Collections.Generic;

namespace Api_miviajescr.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public int IdTipoUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public byte[] CorreoElectronico { get; set; } = null!;

    public string? NumeroTelefono { get; set; }

    public byte[] Contraseña { get; set; } = null!;

    public string FotoIdentificacion { get; set; } = null!;

    public decimal PromedioCalificacion { get; set; }

    public bool SesionActiva { get; set; }

    public string Token { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public bool FueValidado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<CalificacionReservaciones> CalificacionReservaciones { get; set; } = new List<CalificacionReservaciones>();

    public virtual ICollection<CalificacionUsuarios> CalificacionUsuariosIdUsuarioCalificadoNavigation { get; set; } = new List<CalificacionUsuarios>();

    public virtual ICollection<CalificacionUsuarios> CalificacionUsuariosIdUsuarioCalificadorNavigation { get; set; } = new List<CalificacionUsuarios>();

    public virtual ICollection<Denuncias> Denuncias { get; set; } = new List<Denuncias>();

    public virtual ICollection<Favoritos> Favoritos { get; set; } = new List<Favoritos>();

    public virtual ICollection<HistoricoLugaresVisitados> HistoricoLugaresVisitados { get; set; } = new List<HistoricoLugaresVisitados>();

    public virtual TipoUsuarios IdTipoUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Inmuebles> Inmuebles { get; set; } = new List<Inmuebles>();

    public virtual ICollection<Reservaciones> Reservaciones { get; set; } = new List<Reservaciones>();
}
