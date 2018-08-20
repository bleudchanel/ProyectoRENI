namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActividadConvenio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActividadConvenio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 300),
                        Descripcion = c.String(maxLength: 300),
                        Observaciones = c.String(maxLength: 500),
                        Fecha = c.DateTime(nullable: false),
                        ColorPrioridad = c.String(),
                        TipoActividadConvenioId = c.Int(nullable: false),
                        IndicadorId = c.Int(),
                        Avance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Indicador", t => t.IndicadorId)
                .ForeignKey("dbo.TipoActividadConvenio", t => t.TipoActividadConvenioId, cascadeDelete: true)
                .Index(t => t.TipoActividadConvenioId)
                .Index(t => t.IndicadorId);
            
            CreateTable(
                "dbo.TipoActividadConvenio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CondicionConvenio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Convenio", "AnioFirma", c => c.Int());
            AddColumn("dbo.Convenio", "CondicionConvenioId", c => c.Int(nullable: false));
            AddColumn("dbo.Documento", "ActividadConvenioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Convenio", "VigenciaHasta", c => c.DateTime());
            AlterColumn("dbo.Convenio", "Objetivo", c => c.String(maxLength: 150));
            AlterColumn("dbo.Documento", "Formato", c => c.String(maxLength: 10));
            CreateIndex("dbo.Convenio", "CondicionConvenioId");
            CreateIndex("dbo.Documento", "ActividadConvenioId");
            AddForeignKey("dbo.Convenio", "CondicionConvenioId", "dbo.CondicionConvenio", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Documento", "ActividadConvenioId", "dbo.ActividadConvenio", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documento", "ActividadConvenioId", "dbo.ActividadConvenio");
            DropForeignKey("dbo.Convenio", "CondicionConvenioId", "dbo.CondicionConvenio");
            DropForeignKey("dbo.ActividadConvenio", "TipoActividadConvenioId", "dbo.TipoActividadConvenio");
            DropForeignKey("dbo.ActividadConvenio", "IndicadorId", "dbo.Indicador");
            DropIndex("dbo.Documento", new[] { "ActividadConvenioId" });
            DropIndex("dbo.Convenio", new[] { "CondicionConvenioId" });
            DropIndex("dbo.ActividadConvenio", new[] { "IndicadorId" });
            DropIndex("dbo.ActividadConvenio", new[] { "TipoActividadConvenioId" });
            AlterColumn("dbo.Documento", "Formato", c => c.String(maxLength: 5));
            AlterColumn("dbo.Convenio", "Objetivo", c => c.String());
            AlterColumn("dbo.Convenio", "VigenciaHasta", c => c.DateTime(nullable: false));
            DropColumn("dbo.Documento", "ActividadConvenioId");
            DropColumn("dbo.Convenio", "CondicionConvenioId");
            DropColumn("dbo.Convenio", "AnioFirma");
            DropTable("dbo.CondicionConvenio");
            DropTable("dbo.TipoActividadConvenio");
            DropTable("dbo.ActividadConvenio");
        }
    }
}
