using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class TipoContactos
    {
        [Required(ErrorMessage = "El id tipo contacto es obligatorio")]
        public int idTipoContacto { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string descripcionTipoContacto { get; set; }

    }
}