using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CURSO_FUNDAMENTOS_EF.Models
{
    public class Categoria
    {
        public Categoria(Guid categoriaId, string nombre, int peso) 
        {
            this.CategoriaId = categoriaId;
            this.Nombre = nombre;
            this.Peso = peso;
        }

        public Categoria(Guid categoriaId, string nombre, int peso, string descripcion) : this(categoriaId, nombre, peso) 
        {
            this.Descripcion = descripcion;
        }

        //[Key] //DataAnnotations -> Forzamos a utilizar esta propiedad como PK.
        public Guid CategoriaId {get; set;}
        //[Required] //DataAnnotations -> Forzamos a que esta propiedad sea requeridad al momento en el que nosotros intentemos insertar un nuevo registro dentro de la tabla categorias.
        //[MaxLength(150)] //DattaAnnotations -> Limitamos la cantidad de caracteres 
        public string Nombre {get; set;}
        public string Descripcion {get; set;}
        public int Peso {get; set;}
        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas {get; set;}

    }
}