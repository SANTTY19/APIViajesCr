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








app.Run();

