namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlcanceConvenio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlcanceConvenio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 250),
                        Descripcion = c.String(maxLength: 300),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CondicionConvenio", "Descripcion", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CondicionConvenio", "Descripcion");
            DropTable("dbo.AlcanceConvenio");
        }
    }
}
