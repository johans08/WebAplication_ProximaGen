using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAplication_ProximaGen.Models
{
    public class Permissions
    {
        [Required]
        public int idPermiso { get; set; }

        [Required]
        public string permiso { get; set; }
    }
}