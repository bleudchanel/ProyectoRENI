namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramaConvenio3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProgramaConvenio", "TipoProgramaId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProgramaConvenio", "TipoProgramaId");
            AddForeignKey("dbo.ProgramaConvenio", "TipoProgramaId", "dbo.TipoPrograma", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramaConvenio", "TipoProgramaId", "dbo.TipoPrograma");
            DropIndex("dbo.ProgramaConvenio", new[] { "TipoProgramaId" });
            DropColumn("dbo.ProgramaConvenio", "TipoProgramaId");
        }
    }
}
