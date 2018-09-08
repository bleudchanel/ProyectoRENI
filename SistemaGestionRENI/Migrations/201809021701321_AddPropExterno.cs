namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropExterno : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProponenteExterno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 300),
                        InstitucionId = c.Int(nullable: false),
                        Email = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 30),
                        Descripcion = c.String(maxLength: 300),
                        Activo = c.Boolean(nullable: false),
                        Cargo = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institucion", t => t.InstitucionId, cascadeDelete: true)
                .Index(t => t.InstitucionId);
            
            AddColumn("dbo.Proponente", "Cargo", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProponenteExterno", "InstitucionId", "dbo.Institucion");
            DropIndex("dbo.ProponenteExterno", new[] { "InstitucionId" });
            DropColumn("dbo.Proponente", "Cargo");
            DropTable("dbo.ProponenteExterno");
        }
    }
}
