using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGestionRENI.Models
{
    public class Movilidad
    {
        public int Id { get; set; }
        [Display(Name = "Año")]
        public int Anio { get; set; }
        [StringLength(20)]
        public string Semestre { get; set; }
        //Personales
        [StringLength(150)]
        [Display(Name = "Nombres y Apellidos")]
        public string NombresApellidos { get; set; }
        [StringLength(1)]
        public string Sexo { get; set; }
        [StringLength(50)]
        public string Nacionalidad { get; set; }
        public int Edad { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Dirección")]
        [StringLength(200)]
        public string Direccion { get; set; }
        [Display(Name = "Tipo de Documento")]
        [StringLength(15)]
        public string TipoDocumento { get; set; }
        [Display(Name = "Número de Documento")]
        [StringLength(20)]
        public string NumeroDocumento { get; set; }
        [Display(Name = "Teléfono")]
        [StringLength(20)]
        public string Telefono { get; set; }
        [Display(Name = "Dirección Email")]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Facebook { get; set; }
        [StringLength(250)]
        [Display(Name = "Datos de Contacto")]
        public string DatosContacto { get; set; }
        //Académicos
        //[StringLength(250)]
        //[Display(Name = "Universidad de Origen")]
        //public string Universidad { get; set; }
        public Institucion Institucion { get; set; }
        [Display(Name ="Universidad de Origen")]
        public int InstitucionId { get; set; }

        public Dependencia Dependencia { get; set; }
        [Display(Name = "Dependencia Destino")]
        public int DependenciaId { get; set; }

        [StringLength(250)]
        [Display(Name = "Unidad Académica")]
        public string UnidadAcad { get; set; }
        [StringLength(250)]
        [Display(Name = "Carrera que está cursando")]
        public string Carrera { get; set; }
        [StringLength(150)]
        [Display(Name = "Año o semestre que cursa")]
        public string AnioSemestre { get; set; }
        [StringLength(250)]
        [Display(Name = "Nombre de Coordinador Local")]
        public string CoordinadorLocal { get; set; }
        [StringLength(50)]
        [Display(Name = "Número de Celular")]
        public string Celular { get; set; }
        [StringLength(150)]
        public string Skype { get; set; }
        [Display(Name = "Promedio del Alumno")]
        public decimal Promedio { get; set; }
        [Display(Name = "Aclaración")]
        [StringLength(250)]
        public string Aclaración { get; set; }
        public DateTime FechaRegistro { get; set; }
        [StringLength(250)]
        [Display(Name = "Lugar de Registro")]
        public string LugarRegistro { get; set; }

        public Programa Programa { get; set; }
        [Display(Name = "Programa Base")]
        public int ProgramaId { get; set; }

        [Required]
        public bool Activo { get; set; }

    }
}