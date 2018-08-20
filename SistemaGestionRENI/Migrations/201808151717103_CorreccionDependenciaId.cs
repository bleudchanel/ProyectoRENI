namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreccionDependenciaId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Solicitante", "Dependencia_Id", "dbo.Dependencia");
            DropIndex("dbo.Solicitante", new[] { "Dependencia_Id" });
            DropColumn("dbo.Solicitante", "DependenciaId");
            RenameColumn(table: "dbo.Solicitante", name: "Dependencia_Id", newName: "DependenciaId");
            AlterColumn("dbo.Solicitante", "DependenciaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Solicitante", "DependenciaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Solicitante", "DependenciaId");
            AddForeignKey("dbo.Solicitante", "DependenciaId", "dbo.Dependencia", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Solicitante", "DependenciaId", "dbo.Dependencia");
            DropIndex("dbo.Solicitante", new[] { "DependenciaId" });
            AlterColumn("dbo.Solicitante", "DependenciaId", c => c.Int());
            AlterColumn("dbo.Solicitante", "DependenciaId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Solicitante", name: "DependenciaId", newName: "Dependencia_Id");
            AddColumn("dbo.Solicitante", "DependenciaId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Solicitante", "Dependencia_Id");
            AddForeignKey("dbo.Solicitante", "Dependencia_Id", "dbo.Dependencia", "Id");
        }
    }
}
