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

        [Required(ErrorMessage = "El número de tarjeta es obligatorio")]
        [RegularExpression("^[0-9]{16}$", ErrorMessage = "El número de tarjeta debe tener exactamente 16 dígitos y ser numérico")]
        public string numeroTarjeta { get; set; }

        [Required(ErrorMessage = "El mes de expiración es obligatorio")]
        public int expiracionMes { get; set; }

        [Required(ErrorMessage = "El año de expiración es obligatorio")]
        public int expiracionAnno { get; set; }

        [Required(ErrorMessage = "El cvv de expiración es obligatorio")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El CVV debe tener exactamente 3 números")]
        public string cvv { get; set; }

        [Required(ErrorMessage = "El id de la persona es obligatorio")]
        public int Personas_idPersona { get; set; }

        [Required(ErrorMessage = "El id estado es obligatorio")]
        public int Estados_idEstado { get; set; }

    }
    
}