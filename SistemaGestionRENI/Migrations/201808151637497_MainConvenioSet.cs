namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainConvenioSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Convenios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 300),
                        SolicitanteId = c.Int(nullable: false),
                        VigenciaDesde = c.DateTime(nullable: false),
                        VigenciaHasta = c.DateTime(nullable: false),
                        Objetivo = c.String(),
                        IndicadorId = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Indicadors", t => t.IndicadorId, cascadeDelete: true)
                .ForeignKey("dbo.Solicitantes", t => t.SolicitanteId, cascadeDelete: true)
                .Index(t => t.SolicitanteId)
                .Index(t => t.IndicadorId);
            
            CreateTable(
                "dbo.Indicadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Activo = c.Boolean(nullable: false),
                        UnidadMedidaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UnidadMedidas", t => t.UnidadMedidaId, cascadeDelete: true)
                .Index(t => t.UnidadMedidaId);
            
            CreateTable(
                "dbo.UnidadMedidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Solicitantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        DependenciaId = c.Byte(nullable: false),
                        Description = c.String(),
                        Email = c.String(),
                        Telefono = c.String(),
                        Dependencia_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dependencias", t => t.Dependencia_Id)
                .Index(t => t.Dependencia_Id);
            
            CreateTable(
                "dbo.Dependencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Abrev = c.String(),
                        Estado = c.Boolean(nullable: false),
                        EsInterno = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Convenios", "SolicitanteId", "dbo.Solicitantes");
            DropForeignKey("dbo.Solicitantes", "Dependencia_Id", "dbo.Dependencias");
            DropForeignKey("dbo.Convenios", "IndicadorId", "dbo.Indicadors");
            DropForeignKey("dbo.Indicadors", "UnidadMedidaId", "dbo.UnidadMedidas");
            DropIndex("dbo.Solicitantes", new[] { "Dependencia_Id" });
            DropIndex("dbo.Indicadors", new[] { "UnidadMedidaId" });
            DropIndex("dbo.Convenios", new[] { "IndicadorId" });
            DropIndex("dbo.Convenios", new[] { "SolicitanteId" });
            DropTable("dbo.Dependencias");
            DropTable("dbo.Solicitantes");
            DropTable("dbo.UnidadMedidas");
            DropTable("dbo.Indicadors");
            DropTable("dbo.Convenios");
        }
    }
}
