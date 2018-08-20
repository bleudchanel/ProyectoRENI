namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoConvenio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClaseConvenio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Convenio", "ClaseConvenioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Convenio", "ClaseConvenioId");
            AddForeignKey("dbo.Convenio", "ClaseConvenioId", "dbo.ClaseConvenio", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Convenio", "ClaseConvenioId", "dbo.ClaseConvenio");
            DropIndex("dbo.Convenio", new[] { "ClaseConvenioId" });
            DropColumn("dbo.Convenio", "ClaseConvenioId");
            DropTable("dbo.ClaseConvenio");
        }
    }
}
