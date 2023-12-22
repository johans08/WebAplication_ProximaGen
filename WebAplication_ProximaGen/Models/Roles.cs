using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Roles
    {
        [Required(ErrorMessage = "El id rol es obligatorio")]
        public int idRol { get; set; }

        [Required(ErrorMessage = "La descripción del rol es obligatorio")]
        public string descripcionRol { get; set; }
    }
}