namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTiposConvenio : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ClaseConvenio(Nombre,Activo) VALUES('MARCO',1)");
            Sql("INSERT INTO ClaseConvenio(Nombre,Activo) VALUES('ESPECÍFICO',1)");
        }
        
        public override void Down()
        {
        }
    }
}
