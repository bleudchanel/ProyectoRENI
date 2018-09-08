using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI
{
    public class ProgramaConvenioViewModel
    {
        public ProgramaConvenio ProgramaConvenio { get; set; }
        public IEnumerable<Dependencia> Dependencias { get; set; }
        public IEnumerable<Institucion> Instituciones { get; set; }
        public IEnumerable<TipoPrograma> TiposPrograma { get; set; }
        public int ConvenioId { get; set; }
    }
}