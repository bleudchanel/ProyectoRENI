namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgramaInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Programa", "IndicadorId", "dbo.Indicador");
            DropIndex("dbo.Programa", new[] { "IndicadorId" });
            AddColumn("dbo.Programa", "ObjetivoIndicador", c => c.Int());
            AddColumn("dbo.Programa", "Resolucion", c => c.String());
            AddColumn("dbo.Programa", "Correlativo", c => c.String());
            AddColumn("dbo.Programa", "AlcanceConvenio_Id", c => c.Int());
            AlterColumn("dbo.ActividadPrograma", "Avance", c => c.Int());
            AlterColumn("dbo.Programa", "VigenciaHasta", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Programa", "IndicadorId", c => c.Int());
            CreateIndex("dbo.Programa", "IndicadorId");
            CreateIndex("dbo.Programa", "AlcanceConvenio_Id");
            AddForeignKey("dbo.Programa", "AlcanceConvenio_Id", "dbo.AlcanceConvenio", "Id");
            AddForeignKey("dbo.Programa", "IndicadorId", "dbo.Indicador", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programa", "IndicadorId", "dbo.Indicador");
            DropForeignKey("dbo.Programa", "AlcanceConvenio_Id", "dbo.AlcanceConvenio");
            DropIndex("dbo.Programa", new[] { "AlcanceConvenio_Id" });
            DropIndex("dbo.Programa", new[] { "IndicadorId" });
            AlterColumn("dbo.Programa", "IndicadorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Programa", "VigenciaHasta", c => c.DateTime());
            AlterColumn("dbo.ActividadPrograma", "Avance", c => c.Int(nullable: false));
            DropColumn("dbo.Programa", "AlcanceConvenio_Id");
            DropColumn("dbo.Programa", "Correlativo");
            DropColumn("dbo.Programa", "Resolucion");
            DropColumn("dbo.Programa", "ObjetivoIndicador");
            CreateIndex("dbo.Programa", "IndicadorId");
            AddForeignKey("dbo.Programa", "IndicadorId", "dbo.Indicador", "Id", cascadeDelete: true);
        }
    }
}
