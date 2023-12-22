using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Contactos
    {
        [Required(ErrorMessage = "El id es obligatorio")]
        public int idContacto { get; set; }

        [Required(ErrorMessage = "La descripción de contacto es obligatorio")]
        public string descripcionContacto { get; set; }

        [Required(ErrorMessage = "El id tipo contacto es obligatorio")]
        public int TipoContactos_idTipoContacto { get; set; }

        [Required(ErrorMessage = "El id persona es obligatorio")]
        public int Personas_idPersona { get; set; }
    }
}