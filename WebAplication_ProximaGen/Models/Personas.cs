using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Personas
    {
        [Required(ErrorMessage = "El id persona es obligatorio")]
        public int idPersona { get; set; }

        [Required(ErrorMessage = "El numero de tarjeta es obligatorio")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "El número de cédula debe tener exactamente 9 dígitos y ser numérico")]
        public int cedula { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "El segundo apellido es obligatorio")]
        public string apellido2 { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatorio")]
        public DateTime fechaNacimiento { get; set; }

        [Required(ErrorMessage = "El id género es obligatorio")]
        public int Generos_idGenero { get; set; }

        [Required(ErrorMessage = "El id estado es obligatorio")]
        public int Estados_idEstado { get; set; }

    }
}