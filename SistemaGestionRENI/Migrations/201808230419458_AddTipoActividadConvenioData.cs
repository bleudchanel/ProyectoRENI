namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipoActividadConvenioData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TipoActividadConvenio(Nombre,Activo) VALUES('Inicio',1)");
            Sql("INSERT INTO TipoActividadConvenio(Nombre,Activo) VALUES('Evento',1)");
            Sql("INSERT INTO TipoActividadConvenio(Nombre,Activo) VALUES('Informe',1)");
            Sql("INSERT INTO TipoActividadConvenio(Nombre,Activo) VALUES('Cierre',1)");
        }
        
        public override void Down()
        {
        }
    }
}
