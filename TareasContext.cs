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
    }
}