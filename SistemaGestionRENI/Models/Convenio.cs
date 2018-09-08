using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class Convenio
    {

        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Nombre { get; set; }

        public Solicitante Solicitante { get; set; }
        public int? SolicitanteId { get; set; }

        [Range(1990,2200, ErrorMessage = "Ingrese un año válido")]
        [Display(Name = "Año Firma")]
        public int? AnioFirma { get; set; }

        [Required]
        [Display(Name = "Vigencia Desde")]
        public DateTime VigenciaDesde { get; set; }

        [Required]
        [Display(Name = "Vigencia Hasta")]
        public DateTime VigenciaHasta { get; set; }

        [Required]
        public string Objetivo { get; set; }
        public string Obligaciones { get; set; }
        [Display(Name = "Obligaciones de Contraparte")]
        public string Derechos { get; set; }

        [ForeignKey("DependenciaConvenio")]
        [Display(Name = "Dependencia Principal")]
        public int? DependenciaConvenioId { get; set; }
        public Dependencia DependenciaConvenio { get; set; }

        [Display(Name = "Institución Principal")]
        public int? InstitucionId { get; set; }
        public Institucion Institucion { get; set; }

        public Indicador Indicador { get; set; }
        [Display(Name = "Indicador")]
        public int? IndicadorId { get; set; }

        [Display(Name = "Objetivo por Indicador")]
        public int? ObjetivoIndicador { get; set; }

        public AlcanceConvenio AlcanceConvenio { get; set; }
        [Display(Name="Resolución")]
        public string Resolucion { get; set; }

        [Display(Name = "Correlativo Documentación")]
        public string Correlativo { get; set; }

        [Required]
        [Display(Name = "Alcance de Convenio")]
        public int AlcanceConvenioId { get; set; }

        
        public ClaseConvenio ClaseConvenio { get; set; }
        [Required]
        [Display(Name = "Clase de Convenio")]
        public int ClaseConvenioId { get; set; }

       
        public CondicionConvenio CondicionConvenio { get; set; }
        [Required]
        [Display(Name = "Condición de Convenio")]
        public int CondicionConvenioId { get; set; }

        public bool Activo { get; set; }

        [StringLength(300)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
       
        [ForeignKey("ProponenteInterno")]
        [Display(Name = "Proponente Interno")]
        public int? ProponenteIntId { get; set; }
        public Proponente ProponenteInterno { get; set; }

        //[ForeignKey("ProponenteExterno")]
        //[Display(Name = "Proponente Externo")]
        //public int? ProponenteExtId { get; set; }
        //public Proponente ProponenteExterno { get; set; }

        public ProponenteExterno ProponenteExterno { get; set; }
        [Display(Name = "Proponente Externo")]
        public int? ProponenteExternoId { get; set; }

        [ForeignKey("ConvenioPadre")]
        [Display(Name = "Convenio Base")]
        public int? ConvenioPadreId { get; set; }
        public Convenio ConvenioPadre { get; set; }

        [ForeignKey("Dependencia1")]
        [Display(Name = "Dependencia Relacionada 1")]
        public int? Dependencia1Id { get; set; }
        public Dependencia Dependencia1 { get; set; }

        [ForeignKey("Dependencia2")]
        [Display(Name = "Dependencia Relacionada 2")]
        public int? Dependencia2Id { get; set; }
        public Dependencia Dependencia2 { get; set; }

        [ForeignKey("Dependencia3")]
        [Display(Name = "Dependencia Relacionada 3")]
        public int? Dependencia3Id { get; set; }
        public Dependencia Dependencia3 { get; set; }

    }
}