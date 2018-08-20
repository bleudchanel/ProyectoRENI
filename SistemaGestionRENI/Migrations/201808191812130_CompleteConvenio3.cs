namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompleteConvenio3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convenio", "Obligaciones", c => c.String());
            AddColumn("dbo.Convenio", "Derechos", c => c.String());
            AddColumn("dbo.Convenio", "Activo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Convenio", "ConvenioPadreId", c => c.Int());
            AddColumn("dbo.Convenio", "Dependencia1Id", c => c.Int());
            AddColumn("dbo.Convenio", "Dependencia2Id", c => c.Int());
            AddColumn("dbo.Convenio", "Dependencia3Id", c => c.Int());
            AddColumn("dbo.Proponente", "Nombre", c => c.String(maxLength: 300));
            AlterColumn("dbo.Convenio", "Objetivo", c => c.String(nullable: false));
            CreateIndex("dbo.Convenio", "ConvenioPadreId");
            CreateIndex("dbo.Convenio", "Dependencia1Id");
            CreateIndex("dbo.Convenio", "Dependencia2Id");
            CreateIndex("dbo.Convenio", "Dependencia3Id");
            AddForeignKey("dbo.Convenio", "ConvenioPadreId", "dbo.Convenio", "Id");
            AddForeignKey("dbo.Convenio", "Dependencia1Id", "dbo.Dependencia", "Id");
            AddForeignKey("dbo.Convenio", "Dependencia2Id", "dbo.Dependencia", "Id");
            AddForeignKey("dbo.Convenio", "Dependencia3Id", "dbo.Dependencia", "Id");
            DropColumn("dbo.Proponente", "Nombres");
            DropColumn("dbo.Proponente", "Apellidos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proponente", "Apellidos", c => c.String(maxLength: 250));
            AddColumn("dbo.Proponente", "Nombres", c => c.String(maxLength: 250));
            DropForeignKey("dbo.Convenio", "Dependencia3Id", "dbo.Dependencia");
            DropForeignKey("dbo.Convenio", "Dependencia2Id", "dbo.Dependencia");
            DropForeignKey("dbo.Convenio", "Dependencia1Id", "dbo.Dependencia");
            DropForeignKey("dbo.Convenio", "ConvenioPadreId", "dbo.Convenio");
            DropIndex("dbo.Convenio", new[] { "Dependencia3Id" });
            DropIndex("dbo.Convenio", new[] { "Dependencia2Id" });
            DropIndex("dbo.Convenio", new[] { "Dependencia1Id" });
            DropIndex("dbo.Convenio", new[] { "ConvenioPadreId" });
            AlterColumn("dbo.Convenio", "Objetivo", c => c.String(maxLength: 150));
            DropColumn("dbo.Proponente", "Nombre");
            DropColumn("dbo.Convenio", "Dependencia3Id");
            DropColumn("dbo.Convenio", "Dependencia2Id");
            DropColumn("dbo.Convenio", "Dependencia1Id");
            DropColumn("dbo.Convenio", "ConvenioPadreId");
            DropColumn("dbo.Convenio", "Activo");
            DropColumn("dbo.Convenio", "Derechos");
            DropColumn("dbo.Convenio", "Obligaciones");
        }
    }
}
