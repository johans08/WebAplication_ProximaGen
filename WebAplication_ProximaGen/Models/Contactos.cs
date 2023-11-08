using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Contactos
    {
        [Required]
        public int idContacto { get; set; }

        [Required]
        public string descripcionContacto { get; set; }

        [Required]
        public int TipoContactos_idTipoContacto { get; set; }

        [Required]
        public int Personas_idPersona { get; set; }
    }
}