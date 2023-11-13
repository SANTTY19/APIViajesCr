using Api_miviajescr.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EjemploMVCContext>(options =>
{
    options.UseSqlServer("name=ConnectionString:DefaultConnection");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//tipos de usuario
//get tipos de usuarios
app.MapGet("/TiposUsuarios", async (EjemploMVCContext context) =>
    {
        return Results.Ok(await context.TipoUsuarios.ToListAsync());
    }
    ).Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status500InternalServerError);

//post tipos de usuarios
app.MapPost("/TiposUsuarios", async (EjemploMVCContext context, TipoUsuarios tipoUsuario) =>
{
    if (tipoUsuario != null)
    {
        tipoUsuario.FechaCreacion = DateTime.Now;
        context.TipoUsuarios.Add(tipoUsuario);
        await context.SaveChangesAsync();
        return Results.Created($"/TiposUsuarios/{tipoUsuario.IdTipoUsuario}", tipoUsuario);
    }
    else
    {
        return Results.BadRequest("Datos de TipoUsuario no válidos");
    }
}).Produces(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);



//tipo de inmuebles
//get tipos de inmuebles
app.MapGet("/TipoInmuebles", async (EjemploMVCContext context) =>
{
    var tiposInmuebles = await context.TipoInmuebles.ToListAsync();
    return Results.Ok(tiposInmuebles);
}).Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status500InternalServerError);

//post tipos de inmuebles
app.MapPost("/TipoInmuebles", async (EjemploMVCContext context, TipoInmuebles tipoInmueble) =>
{
    if (tipoInmueble != null)
    {
        tipoInmueble.FechaCreacion = DateTime.Now;
        context.TipoInmuebles.Add(tipoInmueble);
        await context.SaveChangesAsync();
        var response = new
        {
            idTipoInmueble = tipoInmueble.IdTipoInmueble,
            tipoInmueble = tipoInmueble.TipoInmueble,
            estaActivo = tipoInmueble.EstaActivo,
            fechaCreacion = tipoInmueble.FechaCreacion.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
        };
        return Results.Created($"/TipoInmuebles/{tipoInmueble.IdTipoInmueble}", response);
    }
    else
    {
        return Results.BadRequest("Datos de TipoInmueble no válidos");
    }
}).Produces(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);


// Creacion de perfiles publicos
// GET perfiles de usuarios
app.MapGet("/PerfilesUsuarios", async (EjemploMVCContext context) =>
{
    var perfilesUsuarios = await context.Usuarios.ToListAsync();
    return Results.Ok(perfilesUsuarios);
}).Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status500InternalServerError);

// POST perfiles publicos
app.MapPost("/PerfilesUsuarios", async (EjemploMVCContext context, Usuarios usuario) =>
{
    if (usuario != null)
    {
        // Establecer propiedades del usuario manualmente (simplificado)
        usuario.FechaCreacion = DateTime.Now;
        usuario.EstaActivo = true;

        // Puedes ajustar aquí para incluir solo los campos que deseas
        var perfilSimplificado = new
        {
            usuario.IdUsuario,
            usuario.IdTipoUsuario,
            usuario.Nombre,
            usuario.Apellidos,
            usuario.FechaNacimiento,
            usuario.CorreoElectronico,
            usuario.NumeroTelefono,
            usuario.Contraseña,
            usuario.FotoIdentificacion,
            usuario.PromedioCalificacion,
            usuario.SesionActiva,
            usuario.Token,
            usuario.EstaActivo,
            usuario.FueValidado,
            usuario.FechaCreacion
        };

        context.Usuarios.Add(usuario);
        await context.SaveChangesAsync();

        return Results.Created($"/PerfilesUsuarios/{usuario.IdUsuario}", perfilSimplificado);
    }
    else
    {
        return Results.BadRequest("Datos de Usuario no válidos");
    }
}).Produces(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);

// PUT perfiles publicos
app.MapPut("/PerfilesUsuarios/{id}", async (EjemploMVCContext context, int id, Usuarios usuarioActualizado) =>
{
    var usuarioExistente = await context.Usuarios.FindAsync(id);

    if (usuarioExistente != null)
    {
        // Actualizar solo las propiedades que deben ser modificadas
        usuarioExistente.Nombre = usuarioActualizado.Nombre;
        usuarioExistente.Apellidos = usuarioActualizado.Apellidos;
        usuarioExistente.FechaNacimiento = usuarioActualizado.FechaNacimiento;
        usuarioExistente.CorreoElectronico = usuarioActualizado.CorreoElectronico;
        usuarioExistente.NumeroTelefono = usuarioActualizado.NumeroTelefono;
        usuarioExistente.Contraseña = usuarioActualizado.Contraseña;
        usuarioExistente.FotoIdentificacion = usuarioActualizado.FotoIdentificacion;
        usuarioExistente.PromedioCalificacion = usuarioActualizado.PromedioCalificacion;
        usuarioExistente.SesionActiva = usuarioActualizado.SesionActiva;
        usuarioExistente.Token = usuarioActualizado.Token;
        usuarioExistente.EstaActivo = usuarioActualizado.EstaActivo;
        usuarioExistente.FueValidado = usuarioActualizado.FueValidado;

        await context.SaveChangesAsync();

        // Puedes ajustar aquí para incluir solo los campos que deseas en la respuesta
        var usuarioModificado = new
        {
            usuarioExistente.IdUsuario,
            usuarioExistente.IdTipoUsuario,
            usuarioExistente.Nombre,
            usuarioExistente.Apellidos,
            usuarioExistente.FechaNacimiento,
            usuarioExistente.CorreoElectronico,
            usuarioExistente.NumeroTelefono,
            usuarioExistente.Contraseña,
            usuarioExistente.FotoIdentificacion,
            usuarioExistente.PromedioCalificacion,
            usuarioExistente.SesionActiva,
            usuarioExistente.Token,
            usuarioExistente.EstaActivo,
            usuarioExistente.FueValidado,
            usuarioExistente.FechaCreacion
        };

        return Results.Ok(usuarioModificado);
    }
    else
    {
        return Results.NotFound($"Usuario con ID {id} no encontrado");
    }
}).Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

// Get Servicios
app.MapGet("/Servicios", async (EjemploMVCContext context) =>
{
    var servicios = await context.Servicios.ToListAsync();
    return Results.Ok(servicios);
}).Produces<List<Servicios>>();

// Post Servicios
app.MapPost("/Servicios", async (EjemploMVCContext context, Servicios servicio) =>
{
    if (servicio != null)
    {
        servicio.FechaCreacion = DateTime.Now;
        context.Servicios.Add(servicio);
        await context.SaveChangesAsync();
        return Results.Created($"/Servicios/{servicio.IdServicio}", servicio);
    }
    else
    {
        return Results.BadRequest("Datos de Servicio no válidos");
    }
}).Produces(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);

// Get Amenidades
app.MapGet("/Amenidades", async (EjemploMVCContext context) =>
{
    var amenidades = await context.Amenidades.ToListAsync();
    return Results.Ok(amenidades);
}).Produces<List<Amenidades>>();

// Post Amenidades
app.MapPost("/Amenidades", async (EjemploMVCContext context, Amenidades amenidad) =>
{
    if (amenidad != null)
    {
        amenidad.FechaCreacion = DateTime.Now;
        context.Amenidades.Add(amenidad);
        await context.SaveChangesAsync();
        return Results.Created($"/Amenidades/{amenidad.IdAmenidad}", amenidad);
    }
    else
    {
        return Results.BadRequest("Datos de Amenidad no válidos");
    }
}).Produces(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);

// Get Politicas
app.MapGet("/Politicas", async (EjemploMVCContext context) =>
{
    var politicas = await context.Politicas.ToListAsync();
    return Results.Ok(politicas);
}).Produces<List<Politicas>>();

// Post Politicas
app.MapPost("/Politicas", async (EjemploMVCContext context, Politicas politica) =>
{
    if (politica != null)
    {
        politica.FechaCreacion = DateTime.Now;
        context.Politicas.Add(politica);
        await context.SaveChangesAsync();
        return Results.Created($"/Politicas/{politica.IdPolitica}", politica);
    }
    else
    {
        return Results.BadRequest("Datos de Politica no válidos");
    }
}).Produces(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);

// Get Restricciones
app.MapGet("/Restricciones", async (EjemploMVCContext context) =>
{
    var restricciones = await context.Restricciones.ToListAsync();
    return Results.Ok(restricciones);
}).Produces<List<Restricciones>>();

// Post Restricciones
app.MapPost("/Restricciones", async (EjemploMVCContext context, Restricciones restriccion) =>
{
    if (restriccion != null)
    {
        restriccion.FechaCreacion = DateTime.Now;
        context.Restricciones.Add(restriccion);
        await context.SaveChangesAsync();
        return Results.Created($"/Restricciones/{restriccion.IdRestriccion}", restriccion);
    }
    else
    {
        return Results.BadRequest("Datos de Restriccion no válidos");
    }
}).Produces(StatusCodes.Status201Created)
.Produces(StatusCodes.Status400BadRequest);




app.Run();

