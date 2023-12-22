using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class PersonaUsuario
    {
        [Required(ErrorMessage = "Los datos persona es obligatorio")]
        public Personas persona { get; set; }

        [Required(ErrorMessage = "Los datos usuario es obligatorio")]
        public Usuarios usuario { get; set; }

        [Required(ErrorMessage = "Los datos contacto es obligatorio")]
        public Contactos contacto { get; set; }

        [Required(ErrorMessage = "Los datos rol es obligatorio")]
        public Roles rol { get; set; }

     
    }


}