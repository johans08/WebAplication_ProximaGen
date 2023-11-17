using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class AsignarPermisos
    {
        [Required]
        public int idRol { get; set; }

        [Required]
        public int idPermiso { get; set; }

        public string permiso { get; set; }

        public string rol { get; set; }
    }
}