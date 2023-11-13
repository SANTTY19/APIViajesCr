using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_miviajescr.Models;

public partial class EjemploMVCContext : DbContext
{
    public EjemploMVCContext()
    {
    }

    public EjemploMVCContext(DbContextOptions<EjemploMVCContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Amenidades> Amenidades { get; set; }

    public virtual DbSet<AmenidadesPorInmueble> AmenidadesPorInmueble { get; set; }

    public virtual DbSet<CalificacionReservaciones> CalificacionReservaciones { get; set; }

    public virtual DbSet<CalificacionUsuarios> CalificacionUsuarios { get; set; }

    public virtual DbSet<CaracteristicasInmuebles> CaracteristicasInmuebles { get; set; }

    public virtual DbSet<Denuncias> Denuncias { get; set; }

    public virtual DbSet<DisponibilidadInmuebles> DisponibilidadInmuebles { get; set; }

    public virtual DbSet<Favoritos> Favoritos { get; set; }

    public virtual DbSet<HistoricoLugaresVisitados> HistoricoLugaresVisitados { get; set; }

    public virtual DbSet<ImagenesInmueble> ImagenesInmueble { get; set; }

    public virtual DbSet<Inmuebles> Inmuebles { get; set; }

    public virtual DbSet<Politicas> Politicas { get; set; }

    public virtual DbSet<PoliticasPorInmueble> PoliticasPorInmueble { get; set; }

    public virtual DbSet<ReservacionCheckIn> ReservacionCheckIn { get; set; }

    public virtual DbSet<ReservacionCheckOut> ReservacionCheckOut { get; set; }

    public virtual DbSet<Reservaciones> Reservaciones { get; set; }

    public virtual DbSet<Restricciones> Restricciones { get; set; }

    public virtual DbSet<RestriccionesPorInmueble> RestriccionesPorInmueble { get; set; }

    public virtual DbSet<Servicios> Servicios { get; set; }

    public virtual DbSet<ServiciosPorInmueble> ServiciosPorInmueble { get; set; }

    public virtual DbSet<StatusDenuncia> StatusDenuncia { get; set; }

    public virtual DbSet<StatusReservacion> StatusReservacion { get; set; }

    public virtual DbSet<TipoInmuebles> TipoInmuebles { get; set; }

    public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }

    public virtual DbSet<UbicacionInmuebles> UbicacionInmuebles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("viajescr");

        modelBuilder.Entity<Amenidades>(entity =>
        {
            entity.HasKey(e => e.IdAmenidad).HasName("PK__Amenidad__D27CA7D5089CC51B");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<AmenidadesPorInmueble>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdAmenidadNavigation).WithMany()
                .HasForeignKey(d => d.IdAmenidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Amenidade__IdAme__5629CD9C");

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany()
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Amenidade__IdInm__571DF1D5");
        });

        modelBuilder.Entity<CalificacionReservaciones>(entity =>
        {
            entity.HasKey(e => e.IdCalificacionReserva).HasName("PK__Califica__7460F5B5B74F488D");

            entity.Property(e => e.Comentarios)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.PromedioCalificacion).HasColumnType("decimal(9, 2)");

            entity.HasOne(d => d.IdReservacionNavigation).WithMany(p => p.CalificacionReservaciones)
                .HasForeignKey(d => d.IdReservacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__IdRes__73BA3083");

            entity.HasOne(d => d.IdUsuarioNavigation)                   
                .WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__IdUsu__74AE54BC");
        });

        modelBuilder.Entity<CalificacionUsuarios>(entity =>
        {
            entity.HasKey(e => e.IdCalificacionUsuario).HasName("PK__Califica__0B93370B9CB8F026");

            entity.Property(e => e.Comentarios)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.PromedioCalificacion).HasColumnType("decimal(9, 2)");

            entity.HasOne(d => d.IdUsuarioCalificadoNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdUsuarioCalificado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__IdUsu__778AC167");

            entity.HasOne(d => d.IdUsuarioCalificadorNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdUsuarioCalificador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__IdUsu__787EE5A0");
        });

        modelBuilder.Entity<CaracteristicasInmuebles>(entity =>
        {
            entity.HasKey(e => e.IdCaracteristica).HasName("PK__Caracter__8761175CFFC26C5C");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany(p => p.CaracteristicasInmuebles)
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Caracteri__IdInm__4AB81AF0");
        });

        modelBuilder.Entity<Denuncias>(entity =>
        {
            entity.HasKey(e => e.IdDenuncia).HasName("PK__Denuncia__73AFA6C39F588511");

            entity.Property(e => e.Denuncia)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Solucion)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdReservacionNavigation).WithMany(p => p.Denuncias)
                .HasForeignKey(d => d.IdReservacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Denuncias__IdRes__7D439ABD");

            entity.HasOne(d => d.IdStatusDenunciaNavigation).WithMany(p => p.Denuncias)
                .HasForeignKey(d => d.IdStatusDenuncia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Denuncias__IdSta__7F2BE32F");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Denuncias__IdUsu__7E37BEF6");
        });

        modelBuilder.Entity<DisponibilidadInmuebles>(entity =>
        {
            entity.HasKey(e => e.IdDisponibilidad).HasName("PK__Disponib__AE82DB17A0E21001");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaFin).HasColumnType("date");
            entity.Property(e => e.FechaInicio).HasColumnType("date");

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany(p => p.DisponibilidadInmuebles)
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Disponibi__IdInm__4D94879B");
        });

        modelBuilder.Entity<Favoritos>(entity =>
        {
            entity.HasKey(e => e.IdFavorito).HasName("PK__Favorito__39DCEE50B54CDA75");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany(p => p.Favoritos)
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favoritos__IdInm__412EB0B6");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favoritos__IdUsu__4222D4EF");
        });

        modelBuilder.Entity<HistoricoLugaresVisitados>(entity =>
        {
            entity.HasKey(e => e.IdHistoricoLugarVisitado).HasName("PK__Historic__6EA8C6EF021D71A4");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdReservacionNavigation).WithMany(p => p.HistoricoLugaresVisitados)
                .HasForeignKey(d => d.IdReservacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historico__IdRes__6FE99F9F");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historico__IdUsu__70DDC3D8");
        });

        modelBuilder.Entity<ImagenesInmueble>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__Imagenes__B42D8F2AC6CFFB90");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany(p => p.ImagenesInmueble)
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImagenesI__IdInm__44FF419A");
        });

        modelBuilder.Entity<Inmuebles>(entity =>
        {
            entity.HasKey(e => e.IdInmueble).HasName("PK__Inmueble__6B8E7D3EA0B8D785");

            entity.Property(e => e.DescripcionInmuebles)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.PrecioPorNoche).HasColumnType("money");
            entity.Property(e => e.PromedioCalificacion).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.TituloInmueble)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoInmuebleNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdTipoInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inmuebles__IdTip__3E52440B");

            entity.HasOne(d => d.IdUsuarioNavigation)  
                .WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inmuebles__IdUsu__3D5E1FD2");
        });

        modelBuilder.Entity<Politicas>(entity =>
        {
            entity.HasKey(e => e.IdPolitica).HasName("PK__Politica__B7DF5F4601F4B7AF");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<PoliticasPorInmueble>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany()
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Politicas__IdInm__5BE2A6F2");

            entity.HasOne(d => d.IdPoliticaNavigation).WithMany()
                .HasForeignKey(d => d.IdPolitica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Politicas__IdPol__5AEE82B9");
        });

        modelBuilder.Entity<ReservacionCheckIn>(entity =>
        {
            entity.HasKey(e => e.IdReservacionCheckIn).HasName("PK__Reservac__5611C99BCE88CB34");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdReservacionNavigation).WithMany(p => p.ReservacionCheckIn)
                .HasForeignKey(d => d.IdReservacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservaci__IdRes__6A30C649");
        });

        modelBuilder.Entity<ReservacionCheckOut>(entity =>
        {
            entity.HasKey(e => e.IdReservacionCheckIn).HasName("PK__Reservac__5611C99BA9F9D222");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdReservacionNavigation).WithMany(p => p.ReservacionCheckOut)
                .HasForeignKey(d => d.IdReservacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservaci__IdRes__6D0D32F4");
        });

        modelBuilder.Entity<Reservaciones>(entity =>
        {
            entity.HasKey(e => e.IdReservacion).HasName("PK__Reservac__52824637274754BF");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaIngreso).HasColumnType("date");
            entity.Property(e => e.FechaSalida).HasColumnType("date");
            entity.Property(e => e.MontoDescuento).HasColumnType("money");
            entity.Property(e => e.MontoTotal).HasColumnType("money");

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservaci__IdInm__656C112C");

            entity.HasOne(d => d.IdStatusReservacionNavigation).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.IdStatusReservacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservaci__IdSta__6754599E");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservaci__IdUsu__66603565");
        });

        modelBuilder.Entity<Restricciones>(entity =>
        {
            entity.HasKey(e => e.IdRestriccion).HasName("PK__Restricc__B237C62CAECD16A7");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<RestriccionesPorInmueble>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany()
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Restricci__IdInm__60A75C0F");

            entity.HasOne(d => d.IdRestriccionNavigation).WithMany()
                .HasForeignKey(d => d.IdRestriccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Restricci__IdRes__5FB337D6");
        });

        modelBuilder.Entity<Servicios>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__2DCCF9A2B0CEAE72");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<ServiciosPorInmueble>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdInmueblesNavigation).WithMany()
                .HasForeignKey(d => d.IdInmuebles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Servicios__IdInm__52593CB8");

            entity.HasOne(d => d.IdServicioNavigation).WithMany()
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Servicios__IdSer__5165187F");
        });

        modelBuilder.Entity<StatusDenuncia>(entity =>
        {
            entity.HasKey(e => e.IdStatusDenuncia).HasName("PK__StatusDe__A3642D0839FC8A5F");

            entity.Property(e => e.StatusDenuncia1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("StatusDenuncia");
        });

        modelBuilder.Entity<StatusReservacion>(entity =>
        {
            entity.HasKey(e => e.IdStatusReservacion).HasName("PK__StatusRe__15837A451C11F0E9");

            entity.Property(e => e.StatusReservacion1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("StatusReservacion");
        });

        modelBuilder.Entity<TipoInmuebles>(entity =>
        {
            entity.HasKey(e => e.IdTipoInmueble).HasName("PK__TipoInmu__B21A651553FA0F38");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.TipoInmueble)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoUsuarios>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TipoUsua__CA04062BC39CF41B");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UbicacionInmuebles>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("PK__Ubicacio__778CAB1DF1A058A5");

            entity.Property(e => e.Canton)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Distrito)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UbicacionDetalles)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdInmuebleNavigation).WithMany(p => p.UbicacionInmuebles)
                .HasForeignKey(d => d.IdInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ubicacion__IdInm__47DBAE45");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97206CCA33");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.FotoIdentificacion).IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroTelefono)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PromedioCalificacion).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.Token)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoUsuarioNavigation)
                .WithMany()
                .HasForeignKey(d => d.IdTipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IdTipo__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
