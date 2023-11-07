using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Contactos
    {
        public int idContacto { get; set; }
        public string descripcionContacto { get; set; }
        public int TipoContactos_idTipoContacto { get; set; }
        public int Personas_idPersona { get; set; }
    }
}