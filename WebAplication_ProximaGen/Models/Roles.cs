using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Roles
    {
        [Required]
        public int idRol { get; set; }

        [Required]
        public string descripcionRol { get; set; }
    }
}