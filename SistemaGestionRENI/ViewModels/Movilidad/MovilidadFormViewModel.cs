using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI
{
    public class MovilidadFormViewModel
    {
        public Movilidad Movilidad { get; set; }
        //public IEnumerable<Programa> Convenios { get; set; }
        public IEnumerable<Institucion> Instituciones { get; set; }
        public IEnumerable<Dependencia> Dependencias { get; set; }
    }
}