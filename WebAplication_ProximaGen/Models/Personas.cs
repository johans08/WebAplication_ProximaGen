using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Personas
    {
        [Required]
        public int idPersona { get; set; }

        [Required]
        public int cedula { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string apellido { get; set; }

        [Required]
        public string apellido2 { get; set; }

        [Required]
        public DateTime fechaNacimiento { get; set; }

        [Required]
        public int Generos_idGenero { get; set; }

        [Required]
        public int Estados_idEstado { get; set; }

    }
}