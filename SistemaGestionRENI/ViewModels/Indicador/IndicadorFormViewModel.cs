using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI
{
    public class NewIndicadorViewModel
    {
        public IEnumerable<UnidadMedida> UnidadesMedida { get; set; }
        public Indicador Indicador { get; set; }
    }
}