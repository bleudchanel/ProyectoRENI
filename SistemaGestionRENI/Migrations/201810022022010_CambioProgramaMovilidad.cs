namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioProgramaMovilidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramaMovilidad", "TipoProgramaId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramaMovilidad", "TipoProgramaId");
            AddForeignKey("dbo.ProgramaMovilidad", "TipoProgramaId", "dbo.TipoPrograma", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramaMovilidad", "TipoProgramaId", "dbo.TipoPrograma");
            DropIndex("dbo.ProgramaMovilidad", new[] { "TipoProgramaId" });
            DropColumn("dbo.ProgramaMovilidad", "TipoProgramaId");
        }
    }
}
