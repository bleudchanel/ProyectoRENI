using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class Proponente
    {
        public int Id { get; set; }
        [StringLength(300)]
        public string Nombre { get; set; }
        public Dependencia Dependencia { get; set; }
        public int DependenciaId { get; set; }
        [StringLength(50)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        [StringLength(30)]
        [Display(Name = "Número Telefónico")]
        public string Telefono { get; set; }
        [StringLength(300)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}