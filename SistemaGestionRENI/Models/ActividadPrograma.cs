using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class ActividadPrograma
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Nombre { get; set; }
        [StringLength(300)]
        public string Descripcion { get; set; }
        [StringLength(500)]
        public string Observaciones { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public string ColorPrioridad { get; set; }
        public TipoActividadPrograma TipoActividadPrograma { get; set; }
        public int TipoActividadProgramaId { get; set; }
        public Indicador Indicador { get; set; }
        public int? IndicadorId { get; set; }
        public int Avance { get; set; }
    }
}