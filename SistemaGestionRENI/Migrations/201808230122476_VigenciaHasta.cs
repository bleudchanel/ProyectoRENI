namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VigenciaHasta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Convenio", "VigenciaHasta", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Convenio", "VigenciaHasta", c => c.DateTime());
        }
    }
}
