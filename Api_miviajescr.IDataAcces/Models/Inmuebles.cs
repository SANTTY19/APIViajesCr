using System;
using System.Collections.Generic;

namespace Api_miviajescr.IDataAcces.Models;

public partial class Inmuebles
{
    public int IdInmueble { get; set; }

    public int IdUsuario { get; set; }

    public int IdTipoInmueble { get; set; }

    public string TituloInmueble { get; set; } = null!;

    public string DescripcionInmuebles { get; set; } = null!;

    public decimal PrecioPorNoche { get; set; }

    public decimal PromedioCalificacion { get; set; }

    public bool EstaActivo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<CaracteristicasInmuebles> CaracteristicasInmuebles { get; set; } = new List<CaracteristicasInmuebles>();

    public virtual ICollection<DisponibilidadInmuebles> DisponibilidadInmuebles { get; set; } = new List<DisponibilidadInmuebles>();

    public virtual ICollection<Favoritos> Favoritos { get; set; } = new List<Favoritos>();

    public virtual TipoInmuebles IdTipoInmuebleNavigation { get; set; } = null!;

    public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<ImagenesInmueble> ImagenesInmueble { get; set; } = new List<ImagenesInmueble>();

    public virtual ICollection<Reservaciones> Reservaciones { get; set; } = new List<Reservaciones>();

    public virtual ICollection<UbicacionInmuebles> UbicacionInmuebles { get; set; } = new List<UbicacionInmuebles>();
}
