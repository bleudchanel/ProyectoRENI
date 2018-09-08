using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class ClaseConvenio
    {
        public int Id { get; set; }
        [Required]
        [StringLength(4)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }
        
        [Required]
        public bool Activo { get; set; }
    }
}