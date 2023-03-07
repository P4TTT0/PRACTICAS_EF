using CURSO_FUNDAMENTOS_EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB")); //Metodo que nos permite agregar un contexto de base de datos en memoria.
builder.Services.AddSqlServer<TareasContext>(@"Data Source = DESKTOP-RNP88KR\MSSQLSERVERDEV; Initial Catalog = TareasDb; user id=sa; password = sa; Trusted_Connection=True; Integrated Security=True;Trust Server Certificate=true");
//Configura una instancia de SQL Server mediante un PATH (CADENA DE CONEXION)
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
}); // Creamos un ENDPOINT que devolvera un mensaje que indica si la base de datos utilizada por el contexto se ha creado correctamente.

app.Run();
