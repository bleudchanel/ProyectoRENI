using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI
{
    public class ActividadConvenioViewModel
    {
        public ActividadConvenio ActividadConvenio { get; set; }
        public IEnumerable<Indicador> Indicadores { get; set; }
        public IEnumerable<TipoActividadConvenio> TiposActividad { get; set; }
        public int ConvenioId { get; set; }
    }
}