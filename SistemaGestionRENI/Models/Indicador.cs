using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class Indicador
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public UnidadMedida UnidadMedida { get; set; }
        public int UnidadMedidaId { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}