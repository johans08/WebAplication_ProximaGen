using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Status
    {
        [Required(ErrorMessage = "El id Estado es obligatorio")]
        public int idEstado { get; set; }

        [Required(ErrorMessage = "La descripcion del estado es obligatoria")]
        public string descripcionEstado { get; set; }
    }
}