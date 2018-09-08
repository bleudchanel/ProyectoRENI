namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodigos1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convenio", "AlcanceConvenioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Convenio", "AlcanceConvenioId");
            AddForeignKey("dbo.Convenio", "AlcanceConvenioId", "dbo.AlcanceConvenio", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Convenio", "AlcanceConvenioId", "dbo.AlcanceConvenio");
            DropIndex("dbo.Convenio", new[] { "AlcanceConvenioId" });
            DropColumn("dbo.Convenio", "AlcanceConvenioId");
        }
    }
}
