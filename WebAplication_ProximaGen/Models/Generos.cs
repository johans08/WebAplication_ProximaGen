using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Generos
    {
        [Required(ErrorMessage = "El id Estado es obligatorio")]
        public int idGenero { get; set; }

        [Required(ErrorMessage = "La descripcion del estado es obligatoria")]
        public string genero { get; set; }
    }
}