namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramaConvenio22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgramaConvenio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(maxLength: 150),
                        DocumentoIdentidad = c.String(maxLength: 12),
                        InstitucionId = c.Int(nullable: false),
                        DependenciaId = c.Int(),
                        ProgramaMovEst = c.String(maxLength: 50),
                        ConvenioId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Convenio", t => t.ConvenioId, cascadeDelete: true)
                .ForeignKey("dbo.Dependencia", t => t.DependenciaId)
                .ForeignKey("dbo.Institucion", t => t.InstitucionId, cascadeDelete: true)
                .Index(t => t.InstitucionId)
                .Index(t => t.DependenciaId)
                .Index(t => t.ConvenioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramaConvenio", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.ProgramaConvenio", "DependenciaId", "dbo.Dependencia");
            DropForeignKey("dbo.ProgramaConvenio", "ConvenioId", "dbo.Convenio");
            DropIndex("dbo.ProgramaConvenio", new[] { "ConvenioId" });
            DropIndex("dbo.ProgramaConvenio", new[] { "DependenciaId" });
            DropIndex("dbo.ProgramaConvenio", new[] { "InstitucionId" });
            DropTable("dbo.ProgramaConvenio");
        }
    }
}
