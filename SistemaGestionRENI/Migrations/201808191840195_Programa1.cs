namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Programa1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActividadPrograma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 300),
                        Descripcion = c.String(maxLength: 300),
                        Observaciones = c.String(maxLength: 500),
                        Fecha = c.DateTime(nullable: false),
                        ColorPrioridad = c.String(),
                        TipoActividadProgramaId = c.Int(nullable: false),
                        IndicadorId = c.Int(),
                        Avance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Indicador", t => t.IndicadorId)
                .ForeignKey("dbo.TipoActividadPrograma", t => t.TipoActividadProgramaId, cascadeDelete: true)
                .Index(t => t.TipoActividadProgramaId)
                .Index(t => t.IndicadorId);
            
            CreateTable(
                "dbo.TipoActividadPrograma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Programa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 300),
                        AnioFirma = c.Int(),
                        VigenciaDesde = c.DateTime(nullable: false),
                        VigenciaHasta = c.DateTime(),
                        Objetivo = c.String(nullable: false),
                        Obligaciones = c.String(),
                        Derechos = c.String(),
                        TipoProgramaId = c.Int(nullable: false),
                        DependenciaProgramaId = c.Int(),
                        IndicadorId = c.Int(nullable: false),
                        CondicionProgramaId = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        Descripcion = c.String(maxLength: 300),
                        ProponenteIntId = c.Int(),
                        ProponenteExtId = c.Int(),
                        ConvenioPadreId = c.Int(),
                        Dependencia1Id = c.Int(),
                        Dependencia2Id = c.Int(),
                        Dependencia3Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CondicionPrograma", t => t.CondicionProgramaId, cascadeDelete: true)
                .ForeignKey("dbo.Convenio", t => t.ConvenioPadreId)
                .ForeignKey("dbo.Dependencia", t => t.Dependencia1Id)
                .ForeignKey("dbo.Dependencia", t => t.Dependencia2Id)
                .ForeignKey("dbo.Dependencia", t => t.Dependencia3Id)
                .ForeignKey("dbo.Dependencia", t => t.DependenciaProgramaId)
                .ForeignKey("dbo.Indicador", t => t.IndicadorId, cascadeDelete: true)
                .ForeignKey("dbo.Proponente", t => t.ProponenteExtId)
                .ForeignKey("dbo.Proponente", t => t.ProponenteIntId)
                .ForeignKey("dbo.TipoPrograma", t => t.TipoProgramaId, cascadeDelete: true)
                .Index(t => t.TipoProgramaId)
                .Index(t => t.DependenciaProgramaId)
                .Index(t => t.IndicadorId)
                .Index(t => t.CondicionProgramaId)
                .Index(t => t.ProponenteIntId)
                .Index(t => t.ProponenteExtId)
                .Index(t => t.ConvenioPadreId)
                .Index(t => t.Dependencia1Id)
                .Index(t => t.Dependencia2Id)
                .Index(t => t.Dependencia3Id);
            
            CreateTable(
                "dbo.CondicionPrograma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoPrograma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Programa", "TipoProgramaId", "dbo.TipoPrograma");
            DropForeignKey("dbo.Programa", "ProponenteIntId", "dbo.Proponente");
            DropForeignKey("dbo.Programa", "ProponenteExtId", "dbo.Proponente");
            DropForeignKey("dbo.Programa", "IndicadorId", "dbo.Indicador");
            DropForeignKey("dbo.Programa", "DependenciaProgramaId", "dbo.Dependencia");
            DropForeignKey("dbo.Programa", "Dependencia3Id", "dbo.Dependencia");
            DropForeignKey("dbo.Programa", "Dependencia2Id", "dbo.Dependencia");
            DropForeignKey("dbo.Programa", "Dependencia1Id", "dbo.Dependencia");
            DropForeignKey("dbo.Programa", "ConvenioPadreId", "dbo.Convenio");
            DropForeignKey("dbo.Programa", "CondicionProgramaId", "dbo.CondicionPrograma");
            DropForeignKey("dbo.ActividadPrograma", "TipoActividadProgramaId", "dbo.TipoActividadPrograma");
            DropForeignKey("dbo.ActividadPrograma", "IndicadorId", "dbo.Indicador");
            DropIndex("dbo.Programa", new[] { "Dependencia3Id" });
            DropIndex("dbo.Programa", new[] { "Dependencia2Id" });
            DropIndex("dbo.Programa", new[] { "Dependencia1Id" });
            DropIndex("dbo.Programa", new[] { "ConvenioPadreId" });
            DropIndex("dbo.Programa", new[] { "ProponenteExtId" });
            DropIndex("dbo.Programa", new[] { "ProponenteIntId" });
            DropIndex("dbo.Programa", new[] { "CondicionProgramaId" });
            DropIndex("dbo.Programa", new[] { "IndicadorId" });
            DropIndex("dbo.Programa", new[] { "DependenciaProgramaId" });
            DropIndex("dbo.Programa", new[] { "TipoProgramaId" });
            DropIndex("dbo.ActividadPrograma", new[] { "IndicadorId" });
            DropIndex("dbo.ActividadPrograma", new[] { "TipoActividadProgramaId" });
            DropTable("dbo.TipoPrograma");
            DropTable("dbo.CondicionPrograma");
            DropTable("dbo.Programa");
            DropTable("dbo.TipoActividadPrograma");
            DropTable("dbo.ActividadPrograma");
        }
    }
}
