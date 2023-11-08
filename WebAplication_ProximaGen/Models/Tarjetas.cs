using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAplication_ProximaGen.Models
{
    public class Tarjetas
    {
        [Required(ErrorMessage = "El id es obligatorio")]
        public int idTarjeta { get; set; }

        [StringLength(16)]
        [Required(ErrorMessage = "La descripcion del estado es obligatoria")]
        public string numeroTarjeta { get; set; }

        [Required(ErrorMessage = "El mes de expiracion es obligatorio")]
        public int expiracionMes { get; set; }

        [Required(ErrorMessage = "El año de expiracion es obligatorio")]
        public int expiracionAnno { get; set; }

        [Required(ErrorMessage = "El cvv de expiracion es obligatorio")]
        public string cvv { get; set; }

        [Required(ErrorMessage = "El id de la persona es obligatorio")]
        public int Personas_idPersona { get; set; }

        [Required(ErrorMessage = "El id estado es obligatorio")]
        public int Estados_idEstado { get; set; }

    }
    
}