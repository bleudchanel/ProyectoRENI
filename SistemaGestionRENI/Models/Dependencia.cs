using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class Dependencia
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "Abreviación")]
        public string Abrev { get; set; }
        public bool Estado { get; set; }
        public bool EsInterno { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "País o Ubicación")]
        public string Pais { get; set; }
    }
}