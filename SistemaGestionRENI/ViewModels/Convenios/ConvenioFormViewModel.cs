using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI
{
    public class ConvenioFormViewModel
    {
        public Convenio Convenio { get; set; }
        public IEnumerable<Indicador> Indicadores { get; set; }
        public IEnumerable<Dependencia> DependenciasPrincipal { get; set; }
        public IEnumerable<Institucion> InstitucionesPrincipal { get; set; }
        public IEnumerable<ClaseConvenio> ClasesConvenio { get; set; }
        public IEnumerable<CondicionConvenio> CondicionesConvenio { get; set; }
        public IEnumerable<Proponente> ProponentesInterno { get; set; }
        public IEnumerable<ProponenteExterno> ProponentesExterno { get; set; }
        public IEnumerable<Convenio> ConveniosPadre { get; set; }
        public IEnumerable<Dependencia> Dependencias1 { get; set; }
        public IEnumerable<Dependencia> Dependencias2 { get; set; }
        public IEnumerable<Dependencia> Dependencias3 { get; set; }
        public IEnumerable<AlcanceConvenio> AlcancesConvenios { get; set; }
    }
}