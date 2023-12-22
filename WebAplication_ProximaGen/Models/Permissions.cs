using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Permissions
    {
        [Required(ErrorMessage = "El id es obligatorio")]
        public int idPermiso { get; set; }

        [Required(ErrorMessage = "La descripción de permiso es obligatorio")]
        public string permiso { get; set; }
    }
}