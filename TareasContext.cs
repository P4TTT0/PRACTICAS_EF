using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CURSO_FUNDAMENTOS_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CURSO_FUNDAMENTOS_EF
{
    public class TareasContext: DbContext
    {
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Tarea> Tareas {get; set;}
        public TareasContext(DbContextOptions<TareasContext> options) : base (options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria(Guid.Parse("e9786fb9-0b5a-4e0a-b181-0265123d1e2e"), "Actividades pendientes", 2));
            categoriasInit.Add(new Categoria(Guid.Parse("ac8e7b88-ba94-4525-a2d3-b91afb7b9968"), "Actividades personales", 30));
            categoriasInit.Add(new Categoria(Guid.Parse("16380453-22c4-4971-98f3-20404321d976"), "Actividades terminadas", 12));
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion);
                categoria.Property(p => p.Peso);
                categoria.HasData(categoriasInit);
            });    

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea(Guid.Parse("4c175dee-3cc8-4b85-be90-2d5c4f296557"), Guid.Parse("e9786fb9-0b5a-4e0a-b181-0265123d1e2e"), "Pago de servicios publicos", Prioridad.Media));
            tareasInit.Add(new Tarea(Guid.Parse("51a0aa6d-b01d-4100-bec1-9f91ed98ec30"), Guid.Parse("ac8e7b88-ba94-4525-a2d3-b91afb7b9968"), "Terminar curso ASP.NET", Prioridad.Alta));

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea"); //Indicamos que será una tabla y el nombre de la misma
                tarea.HasKey(t => t.TareaId); //Indicamos que la talba posee PK
                tarea.HasOne(t => t.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId); //Indicamos la FK de conexion entre Tarea y Categoria.
                tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200); //Indicamos que la propiedad TITULO es NOT NULL y tiene un LEN de 200 caracteres.
                tarea.Property(t => t.Descripcion);
                tarea.Property(t => t.PrioridadTarea);
                tarea.Property(t => t.FechaCreacion);
                tarea.Ignore(t => t.Resumen); //Indicamos que esta propiedad no tendra que ser tomada en cuenta a la hora de realizar la tabla
                tarea.HasData(tareasInit);
            });
        }

    }
}