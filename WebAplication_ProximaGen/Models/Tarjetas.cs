using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAplication_ProximaGen.Models
{
    public class Tarjetas
    {
        public int idTarjeta { get; set; }
        public string numeroTarjeta { get; set; }
        public int expiracionMes { get; set; }
        public int expiracionAnno { get; set; }
        public string cvv { get; set; }
        public int Personas_idPersona { get; set; }
        public int Estados_idEstado { get; set; }

    }
    
}