using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI
{
    public class NewProponenteViewModel
    {
        public IEnumerable<Dependencia> Dependencias { get; set; }
        public Proponente Proponente { get; set; }
    }
}