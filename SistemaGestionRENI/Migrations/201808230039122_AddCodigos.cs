namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodigos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlcanceConvenio", "Codigo", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.ClaseConvenio", "Codigo", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClaseConvenio", "Codigo");
            DropColumn("dbo.AlcanceConvenio", "Codigo");
        }
    }
}
