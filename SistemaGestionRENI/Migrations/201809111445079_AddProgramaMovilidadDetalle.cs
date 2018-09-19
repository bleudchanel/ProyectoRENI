namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramaMovilidadDetalle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProgramaConvenio", "ConvenioId", "dbo.Convenio");
            DropForeignKey("dbo.ProgramaConvenio", "DependenciaId", "dbo.Dependencia");
            DropForeignKey("dbo.ProgramaConvenio", "InstitucionId", "dbo.Institucion");
            DropForeignKey("dbo.ProgramaConvenio", "TipoProgramaId", "dbo.TipoPrograma");
            DropIndex("dbo.ProgramaConvenio", new[] { "InstitucionId" });
            DropIndex("dbo.ProgramaConvenio", new[] { "DependenciaId" });
            DropIndex("dbo.ProgramaConvenio", new[] { "ConvenioId" });
            DropIndex("dbo.ProgramaConvenio", new[] { "TipoProgramaId" });
            CreateTable(
                "dbo.ProgramaMovilidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Activo = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        ConvenioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Convenio", t => t.ConvenioId, cascadeDelete: true)
                .Index(t => t.ConvenioId);
            
            AddColumn("dbo.Convenio", "AdmiteProgramaMov", c => c.Boolean(nullable: false));
            DropTable("dbo.ProgramaConvenio");
        }
        
        public override void Down()
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
                        TipoProgramaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.ProgramaMovilidad", "ConvenioId", "dbo.Convenio");
            DropIndex("dbo.ProgramaMovilidad", new[] { "ConvenioId" });
            DropColumn("dbo.Convenio", "AdmiteProgramaMov");
            DropTable("dbo.ProgramaMovilidad");
            CreateIndex("dbo.ProgramaConvenio", "TipoProgramaId");
            CreateIndex("dbo.ProgramaConvenio", "ConvenioId");
            CreateIndex("dbo.ProgramaConvenio", "DependenciaId");
            CreateIndex("dbo.ProgramaConvenio", "InstitucionId");
            AddForeignKey("dbo.ProgramaConvenio", "TipoProgramaId", "dbo.TipoPrograma", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramaConvenio", "InstitucionId", "dbo.Institucion", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgramaConvenio", "DependenciaId", "dbo.Dependencia", "Id");
            AddForeignKey("dbo.ProgramaConvenio", "ConvenioId", "dbo.Convenio", "Id", cascadeDelete: true);
        }
    }
}
