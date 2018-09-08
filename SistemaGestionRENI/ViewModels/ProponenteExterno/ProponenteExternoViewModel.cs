using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI
{ 
    public class ProponenteExternoViewModel
    {
        public IEnumerable<Institucion> Instituciones { get; set; }
        public ProponenteExterno Proponente { get; set; }
    }
}