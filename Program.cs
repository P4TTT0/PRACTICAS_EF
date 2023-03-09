using CURSO_FUNDAMENTOS_EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CURSO_FUNDAMENTOS_EF.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB")); //Metodo que nos permite agregar un contexto de base de datos en memoria.
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
//Configura una instancia de SQL Server mediante un PATH (CADENA DE CONEXION)
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
}); // Creamos un ENDPOINT que devolvera un mensaje que indica si la base de datos utilizada por el contexto se ha creado correctamente.

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    Tarea tareaActual = dbContext.Tareas.Find(id);
    IResult resultado;

    if(tareaActual != null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();
        resultado = Results.Ok();
    }
    else
    {
        resultado = Results.NotFound();
    }

    return resultado;
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    Tarea tareaActual = dbContext.Tareas.Find(id);
    IResult resultado;

    if (tareaActual != null)
    {
        dbContext.Remove(tareaActual);

        await dbContext.SaveChangesAsync();
        resultado = Results.Ok();
    }
    else
    {
        resultado = Results.NotFound();
    }
});

app.Run();
