using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SistemaGestionRENI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UnidadMedida> UnidadMedidaSet { get; set; }
        public DbSet<Indicador> IndicadorSet { get; set; }
        public DbSet<Solicitante> SolicitanteSet { get; set; }
        public DbSet<Dependencia> DependenciaSet { get; set; }
        public DbSet<CondicionConvenio> CondicionConvenioSet { get; set; }
        public DbSet<ClaseConvenio> ClaseConvenioSet { get; set; }
        public DbSet<Convenio> ConvenioSet { get; set; }
        public DbSet<Proponente> ProponenteSet { get; set; }
        public DbSet<Documento> DocumentoSet { get; set; }
        public DbSet<TipoActividadConvenio> TipoActividadConvenioSet { get; set; }
        public DbSet<ActividadConvenio> ActividadConvenioSet { get; set; }
        public DbSet<Programa> ProgramaSet { get; set; }
        public DbSet<ActividadPrograma> ActividadProgramaSet { get; set; }
        public DbSet<TipoActividadPrograma> TipoActividadProgramaSet { get; set; }
        public DbSet<TipoPrograma> TipoProgramaSet { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}