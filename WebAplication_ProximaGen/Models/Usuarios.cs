using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Usuarios
    {
        [Required]
        public int idUsuarios { get; set; }

        [Required]
        public string nombreUsuarios { get; set; }

        [Required]
        public string contrasenna { get; set; }

        [Required]
        public string correo { get; set; }

        [Required]
        public int Roles_idRol { get; set; }

        [Required]
        public int Personas_idPersona { get; set; }

        [Required]
        public int Estados_idEstado { get; set; }
    }
}