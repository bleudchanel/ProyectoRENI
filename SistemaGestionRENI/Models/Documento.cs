using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class Documento
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }
        [StringLength(10)]
        public string Formato { get; set; }
        [Required]
        public byte[] Contenido { get; set; }

        public Convenio Convenio { get; set; }
        public int ConvenioId { get; set; }

        public ActividadConvenio ActividadConvenio { get; set; }
        public int ActividadConvenioId { get; set; }
    }
}