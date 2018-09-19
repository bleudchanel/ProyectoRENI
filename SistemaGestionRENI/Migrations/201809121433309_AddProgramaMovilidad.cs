namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramaMovilidad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movilidad", "DependenciaId", c => c.Int(nullable: false));
            AddColumn("dbo.Movilidad", "Activo", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Movilidad", "DependenciaId");
            AddForeignKey("dbo.Movilidad", "DependenciaId", "dbo.Dependencia", "Id", cascadeDelete: true);
            DropColumn("dbo.Movilidad", "DirUniversidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movilidad", "DirUniversidad", c => c.String(maxLength: 250));
            DropForeignKey("dbo.Movilidad", "DependenciaId", "dbo.Dependencia");
            DropIndex("dbo.Movilidad", new[] { "DependenciaId" });
            DropColumn("dbo.Movilidad", "Activo");
            DropColumn("dbo.Movilidad", "DependenciaId");
        }
    }
}
