namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivoProponente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proponente", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proponente", "Activo");
        }
    }
}
