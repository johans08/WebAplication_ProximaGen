using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Usuarios
    {
        public int idUsuarios { get; set; }
        public string nombreUsuarios { get; set; }
        public string contrasenna { get; set; }
        public string correo { get; set; }
        public int Roles_idRol { get; set; }
        public int Personas_idPersona { get; set; }
        public int Estados_idEstado { get; set; }
    }
}