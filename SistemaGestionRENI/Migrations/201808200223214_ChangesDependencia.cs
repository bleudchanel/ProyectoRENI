namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesDependencia : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dependencia", "Pais", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dependencia", "Pais", c => c.String(nullable: false));
        }
    }
}
