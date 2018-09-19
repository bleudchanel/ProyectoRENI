using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class ProgramaMovilidad
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de Programa")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required]
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Convenio Convenio { get; set; }
        [Display(Name = "Convenio Base")]
        public int ConvenioId { get; set; }
    }
}