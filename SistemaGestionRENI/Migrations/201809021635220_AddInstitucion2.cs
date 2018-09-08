namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstitucion2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Institucion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Abrev = c.String(nullable: false, maxLength: 50),
                        Ubicacion = c.String(nullable: false, maxLength: 150),
                        EsPrivado = c.Boolean(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        ActividadInstitucion = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Dependencia", "Activo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Dependencia", "PadreId", c => c.Int(nullable: false));
            AddColumn("dbo.Dependencia", "DependenciaFijoId", c => c.Int(nullable: false));
            DropColumn("dbo.Dependencia", "Estado");
            DropColumn("dbo.Dependencia", "EsInterno");
            DropColumn("dbo.Dependencia", "Pais");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dependencia", "Pais", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Dependencia", "EsInterno", c => c.Boolean(nullable: false));
            AddColumn("dbo.Dependencia", "Estado", c => c.Boolean(nullable: false));
            DropColumn("dbo.Dependencia", "DependenciaFijoId");
            DropColumn("dbo.Dependencia", "PadreId");
            DropColumn("dbo.Dependencia", "Activo");
            DropTable("dbo.Institucion");
        }
    }
}
