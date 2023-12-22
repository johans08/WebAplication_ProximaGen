using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class AsignarPermisos
    {
        [Required(ErrorMessage = "El id es obligatorio")]
        public int idRol { get; set; }

        [Required(ErrorMessage = "El id es obligatorio")]
        public int idPermiso { get; set; }

        [Required(ErrorMessage = "El permiso es obligatorio")]
        public string permiso { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio")]
        public string rol { get; set; }
    }
}