namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProponenteSetFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proponentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(maxLength: 250),
                        Apellidos = c.String(maxLength: 250),
                        DependenciaId = c.Int(nullable: false),
                        Email = c.String(),
                        Telefono = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dependencias", t => t.DependenciaId, cascadeDelete: true)
                .Index(t => t.DependenciaId);
            
            AddColumn("dbo.Convenios", "ProponenteIntId", c => c.Int());
            AddColumn("dbo.Convenios", "ProponenteExtId", c => c.Int());
            CreateIndex("dbo.Convenios", "ProponenteIntId");
            CreateIndex("dbo.Convenios", "ProponenteExtId");
            AddForeignKey("dbo.Convenios", "ProponenteExtId", "dbo.Proponentes", "Id");
            AddForeignKey("dbo.Convenios", "ProponenteIntId", "dbo.Proponentes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Convenios", "ProponenteIntId", "dbo.Proponentes");
            DropForeignKey("dbo.Convenios", "ProponenteExtId", "dbo.Proponentes");
            DropForeignKey("dbo.Proponentes", "DependenciaId", "dbo.Dependencias");
            DropIndex("dbo.Proponentes", new[] { "DependenciaId" });
            DropIndex("dbo.Convenios", new[] { "ProponenteExtId" });
            DropIndex("dbo.Convenios", new[] { "ProponenteIntId" });
            DropColumn("dbo.Convenios", "ProponenteExtId");
            DropColumn("dbo.Convenios", "ProponenteIntId");
            DropTable("dbo.Proponentes");
        }
    }
}
