using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class ProponenteExterno
    {
        public int Id { get; set; }
        [StringLength(300)]
        public string Nombre { get; set; }
        public Institucion Instituction { get; set; }
        public int InstitucionId { get; set; }
        [StringLength(50)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        [StringLength(30)]
        [Display(Name = "Número Telefónico")]
        public string Telefono { get; set; }
        [StringLength(300)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required]
        public bool Activo { get; set; }
        [StringLength(150)]
        public string Cargo { get; set; }

    }
}