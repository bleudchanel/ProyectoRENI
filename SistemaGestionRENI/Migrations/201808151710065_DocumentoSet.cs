namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentoSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Formato = c.String(maxLength: 5),
                        Contenido = c.Binary(nullable: false),
                        ConvenioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Convenios", t => t.ConvenioId, cascadeDelete: true)
                .Index(t => t.ConvenioId);
            
            AlterColumn("dbo.Indicadors", "Nombre", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.UnidadMedidas", "Nombre", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Proponentes", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Proponentes", "Telefono", c => c.String(maxLength: 30));
            AlterColumn("dbo.Proponentes", "Descripcion", c => c.String(maxLength: 300));
            AlterColumn("dbo.Solicitantes", "Description", c => c.String(maxLength: 300));
            AlterColumn("dbo.Solicitantes", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Solicitantes", "Telefono", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documentoes", "ConvenioId", "dbo.Convenios");
            DropIndex("dbo.Documentoes", new[] { "ConvenioId" });
            AlterColumn("dbo.Solicitantes", "Telefono", c => c.String());
            AlterColumn("dbo.Solicitantes", "Email", c => c.String());
            AlterColumn("dbo.Solicitantes", "Description", c => c.String());
            AlterColumn("dbo.Proponentes", "Descripcion", c => c.String());
            AlterColumn("dbo.Proponentes", "Telefono", c => c.String());
            AlterColumn("dbo.Proponentes", "Email", c => c.String());
            AlterColumn("dbo.UnidadMedidas", "Nombre", c => c.String());
            AlterColumn("dbo.Indicadors", "Nombre", c => c.String());
            DropTable("dbo.Documentoes");
        }
    }
}
