namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodigos2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Convenio", "IndicadorId", "dbo.Indicador");
            DropForeignKey("dbo.Convenio", "SolicitanteId", "dbo.Solicitante");
            DropIndex("dbo.Convenio", new[] { "SolicitanteId" });
            DropIndex("dbo.Convenio", new[] { "IndicadorId" });
            AlterColumn("dbo.Convenio", "SolicitanteId", c => c.Int());
            AlterColumn("dbo.Convenio", "IndicadorId", c => c.Int());
            CreateIndex("dbo.Convenio", "SolicitanteId");
            CreateIndex("dbo.Convenio", "IndicadorId");
            AddForeignKey("dbo.Convenio", "IndicadorId", "dbo.Indicador", "Id");
            AddForeignKey("dbo.Convenio", "SolicitanteId", "dbo.Solicitante", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Convenio", "SolicitanteId", "dbo.Solicitante");
            DropForeignKey("dbo.Convenio", "IndicadorId", "dbo.Indicador");
            DropIndex("dbo.Convenio", new[] { "IndicadorId" });
            DropIndex("dbo.Convenio", new[] { "SolicitanteId" });
            AlterColumn("dbo.Convenio", "IndicadorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Convenio", "SolicitanteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Convenio", "IndicadorId");
            CreateIndex("dbo.Convenio", "SolicitanteId");
            AddForeignKey("dbo.Convenio", "SolicitanteId", "dbo.Solicitante", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Convenio", "IndicadorId", "dbo.Indicador", "Id", cascadeDelete: true);
        }
    }
}
