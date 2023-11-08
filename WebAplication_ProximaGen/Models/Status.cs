using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Status
    {
        [Required(ErrorMessage = "El id es obligatorio")]
        public int idEstado { get; set; }

        [StringLength(45)]
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string descripcionEstado { get; set; }
    }
}