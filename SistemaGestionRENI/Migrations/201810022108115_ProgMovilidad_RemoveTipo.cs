namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgMovilidad_RemoveTipo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramaMovilidad", "TipoProgramaId", "dbo.TipoPrograma");
            DropIndex("dbo.ProgramaMovilidad", new[] { "TipoProgramaId" });
            DropColumn("dbo.ProgramaMovilidad", "TipoProgramaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProgramaMovilidad", "TipoProgramaId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramaMovilidad", "TipoProgramaId");
            AddForeignKey("dbo.ProgramaMovilidad", "TipoProgramaId", "dbo.TipoPrograma", "Id", cascadeDelete: true);
        }
    }
}
