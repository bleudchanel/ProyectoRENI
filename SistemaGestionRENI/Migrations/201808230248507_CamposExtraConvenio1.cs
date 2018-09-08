namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposExtraConvenio1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Convenio", "ObjetivoIndicador", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Convenio", "ObjetivoIndicador");
        }
    }
}
