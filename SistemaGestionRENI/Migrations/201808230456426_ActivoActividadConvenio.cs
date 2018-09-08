namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivoActividadConvenio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActividadConvenio", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActividadConvenio", "Activo");
        }
    }
}
