using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Usuarios
    {
        [Required(ErrorMessage = "El id usuario es obligatorio")]
        public int idUsuarios { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string nombreUsuarios { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string contrasenna { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        public string correo { get; set; }

        [Required(ErrorMessage = "El id rol es obligatorio")]
        public int Roles_idRol { get; set; }

        [Required(ErrorMessage = "El id persona es obligatorio")]
        public int Personas_idPersona { get; set; }

        [Required(ErrorMessage = "El id estado es obligatorio")]
        public int Estados_idEstado { get; set; }
    }
}