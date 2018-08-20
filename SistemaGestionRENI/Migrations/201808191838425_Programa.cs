namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Programa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convenio", "DependenciaConvenioId", c => c.Int());
            AddColumn("dbo.Dependencia", "Pais", c => c.String(nullable: false));
            AlterColumn("dbo.Dependencia", "Nombre", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Dependencia", "Abrev", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Convenio", "DependenciaConvenioId");
            AddForeignKey("dbo.Convenio", "DependenciaConvenioId", "dbo.Dependencia", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Convenio", "DependenciaConvenioId", "dbo.Dependencia");
            DropIndex("dbo.Convenio", new[] { "DependenciaConvenioId" });
            AlterColumn("dbo.Dependencia", "Abrev", c => c.String());
            AlterColumn("dbo.Dependencia", "Nombre", c => c.String());
            DropColumn("dbo.Dependencia", "Pais");
            DropColumn("dbo.Convenio", "DependenciaConvenioId");
        }
    }
}
