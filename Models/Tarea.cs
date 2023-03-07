using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CURSO_FUNDAMENTOS_EF.Models
{
    public class Tarea
    {
        [Key] //DataAnnotations -> Forzamos a utilizar esta propiedad como PK.
        public Guid TareaId {get; set;}
        [ForeignKey("CategoriaId")] //DataAnnotations -> Forzamos a utilizar esta propiedad como FK bajo el nombre 'CategoriaId'
        public Guid CategoriaId {get; set;}
        [Required] //DataAnnotations -> Forzamos a que esta propiedad sea requeridad al momento en el que nosotros intentemos insertar un nuevo registro dentro de la tabla categorias.
        [MaxLength(200)] //DataAnnotations -> Limitamos la cantidad de caracteres 
        public string Titulo {get; set;}
        public string Descripcion {get; set;}
        public Prioridad PrioridadTarea {get; set;}
        public DateTime FechaCreacion {get; set;}
        public virtual Categoria Categoria {get; set;}
        [NotMapped] //DataAnnotations -> En el momento en el que se realice el mapeo de nuestro contexto hacia la BD, se omita este campo en la creacion de la tabla.
        public string Resumen { get; set; }
    }

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
    
}