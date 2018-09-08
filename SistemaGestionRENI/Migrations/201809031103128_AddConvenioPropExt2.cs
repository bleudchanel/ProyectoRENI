namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConvenioPropExt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convenio", "InstitucionId", c => c.Int());
            CreateIndex("dbo.Convenio", "InstitucionId");
            AddForeignKey("dbo.Convenio", "InstitucionId", "dbo.Institucion", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Convenio", "InstitucionId", "dbo.Institucion");
            DropIndex("dbo.Convenio", new[] { "InstitucionId" });
            DropColumn("dbo.Convenio", "InstitucionId");
        }
    }
}
