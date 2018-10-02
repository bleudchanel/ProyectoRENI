using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class Programa
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Nombre { get; set; }
        [Range(1990, 2200, ErrorMessage = "Ingrese un año válido")]
        public int? AnioFirma { get; set; }
        [Required]
        [Display(Name = "Vigencia Desde")]
        public DateTime VigenciaDesde { get; set; }
        [Required]
        [Display(Name = "Vigencia Desde")]
        public DateTime? VigenciaHasta { get; set; }
        [Required]
        public string Objetivo { get; set; }
        public string Obligaciones { get; set; }
        public string Derechos { get; set; }

        [Required]
        public int TipoProgramaId { get; set; }
        public TipoPrograma TipoPrograma { get; set; }

        [ForeignKey("DependenciaPrograma")]
        public int? DependenciaProgramaId { get; set; }
        public Dependencia DependenciaPrograma { get; set; }

        public Indicador Indicador { get; set; }
        public int? IndicadorId { get; set; }

        [Display(Name = "Objetivo por Indicador")]
        public int? ObjetivoIndicador { get; set; }

        public CondicionPrograma CondicionPrograma { get; set; }
        [Required]
        public int CondicionProgramaId { get; set; }

        public AlcanceConvenio AlcanceConvenio { get; set; }
        [Display(Name = "Resolución")]
        public string Resolucion { get; set; }

        [Display(Name = "Correlativo Documentación")]
        public string Correlativo { get; set; }

        public bool Activo { get; set; }

        [StringLength(300)]
        public string Descripcion { get; set; }

        [ForeignKey("ProponenteInterno")]
        public int? ProponenteIntId { get; set; }
        public Proponente ProponenteInterno { get; set; }

        [ForeignKey("ProponenteExterno")]
        public int? ProponenteExtId { get; set; }
        public Proponente ProponenteExterno { get; set; }

        [ForeignKey("ConvenioPadre")]
        public int? ConvenioPadreId { get; set; }
        public Convenio ConvenioPadre { get; set; }

        [ForeignKey("Dependencia1")]
        public int? Dependencia1Id { get; set; }
        public Dependencia Dependencia1 { get; set; }

        [ForeignKey("Dependencia2")]
        public int? Dependencia2Id { get; set; }
        public Dependencia Dependencia2 { get; set; }

        [ForeignKey("Dependencia3")]
        public int? Dependencia3Id { get; set; }
        public Dependencia Dependencia3 { get; set; }
    }
}