using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI
{
    public class ProgramaMovilidadFormViewModel
    {
        public ProgramaMovilidad ProgramaMovilidad { get; set; }
        public IEnumerable<Convenio> Convenios { get; set; }
        //public IEnumerable<TipoPrograma> TiposPrograma { get; set; }
        public int ConvenioId { get; set; }
    }
}