using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class Institucion
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Abreviación")]
        public string Abrev { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }
        [Required]
        public bool EsPrivado { get; set; }
        [Required]
        public bool Activo { get; set; }
        [StringLength(250)]
        [Display(Name = "Actividad de la Institución")]
        public string ActividadInstitucion { get; set; }
    }
}