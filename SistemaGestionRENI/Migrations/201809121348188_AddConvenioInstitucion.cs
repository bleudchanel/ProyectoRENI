namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConvenioInstitucion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movilidad", "InstitucionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movilidad", "InstitucionId");
            AddForeignKey("dbo.Movilidad", "InstitucionId", "dbo.Institucion", "Id", cascadeDelete: true);
            DropColumn("dbo.Movilidad", "Universidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movilidad", "Universidad", c => c.String(maxLength: 250));
            DropForeignKey("dbo.Movilidad", "InstitucionId", "dbo.Institucion");
            DropIndex("dbo.Movilidad", new[] { "InstitucionId" });
            DropColumn("dbo.Movilidad", "InstitucionId");
        }
    }
}
