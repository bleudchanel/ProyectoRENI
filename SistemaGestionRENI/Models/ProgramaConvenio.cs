using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class ProgramaConvenio
    {
        public int Id { get; set; }

        [Display(Name = "Nombres y Apellidos")]
        [StringLength(150)]
        public string Nombres { get; set; }

        [Display(Name = "Número de Documento de Identidad")]
        [StringLength(12)]
        public string DocumentoIdentidad { get; set; }

        [Display(Name = "Universidad de Origen")]
        public int InstitucionId { get; set; }
        public Institucion Institucion { get; set; }

        [Display(Name = "Dependencia Destino")]
        public int? DependenciaId { get; set; }
        public Dependencia Dependencia { get; set; }

        [Display(Name = "Programa de Movilidad Estudiantil")]
        [StringLength(50)]
        public string ProgramaMovEst { get; set; }

        public Convenio Convenio { get; set; }
        [Display(Name = "Convenio")]
        public int ConvenioId { get; set; }

        [Required]
        public bool Activo { get; set; }

        public TipoPrograma TipoPrograma { get; set; }
        [Display(Name = "Tipo de Programa")]
        public int TipoProgramaId { get; set; }
    }
}