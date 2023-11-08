using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Personas
    {
        public int idPersona { get; set; }
        public int cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string apellido2 { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int Generos_idGenero { get; set; }
        public int Estados_idEstado { get; set; }

    }
}