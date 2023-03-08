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
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion);
                categoria.Property(p => p.Peso);
            });    

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
            });
        }

    }
}