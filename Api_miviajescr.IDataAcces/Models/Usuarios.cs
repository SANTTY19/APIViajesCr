using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public int IdTipoUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string? NumeroTelefono { get; set; }

    public string Contraseña { get; set; } = null!;

    public string FotoIdentificacion { get; set; } = null!;

    public decimal PromedioCalificacion { get; set; }

    public bool SesionActiva { get; set; }

    public string Token { get; set; } = null!;

    public bool EstaActivo { get; set; }

    public bool FueValidado { get; set; }

    public DateTime FechaCreacion { get; set; }



    public virtual TipoUsuarios IdTipoUsuarioNavigation { get; set; } = null!;


}
