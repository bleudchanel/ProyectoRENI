using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI
{
    public class DetailProgramaConvenioViewModel
    {
        public ProgramaMovilidad ProgramaMovilidad { get; set; }
        public IEnumerable<Movilidad> Movilidades { get; set; }
        //public IEnumerable<ProgramaConvenio> Programas { get; set; }
    }
}