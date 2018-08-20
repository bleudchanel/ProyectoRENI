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
        public int SolicitanteId { get; set; }

        public int? AnioFirma { get; set; }
        [Required]
        public DateTime VigenciaDesde { get; set; }
        public DateTime? VigenciaHasta { get; set; }
        [Required]
        public string Objetivo { get; set; }
        public string Obligaciones { get; set; }
        public string Derechos { get; set; }

        [ForeignKey("DependenciaConvenio")]
        public int? DependenciaConvenioId { get; set; }
        public Dependencia DependenciaConvenio { get; set; }

        public Indicador Indicador { get; set; }
        public int IndicadorId { get; set; }

        public ClaseConvenio ClaseConvenio { get; set; }
        public int ClaseConvenioId { get; set; }

        public CondicionConvenio CondicionConvenio { get; set; }
        public int CondicionConvenioId { get; set; }

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