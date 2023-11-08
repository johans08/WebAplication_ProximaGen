using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class TipoContactos
    {
        [Required(ErrorMessage = "El id es obligatorio")]
        public int idTipoContacto { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string descripcionTipoContacto { get; set; }

    }
}