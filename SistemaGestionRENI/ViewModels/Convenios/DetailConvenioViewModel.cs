using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI.ViewModels.Convenios
{
    public class DetailConvenioViewModel
    {
        public Convenio Convenio { get; set; }
        public IEnumerable<Models.ActividadConvenio> Actividades { get; set; }
        public IEnumerable<ProgramaConvenio> Programas { get; set; }
    }
}