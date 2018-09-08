namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposExtraConvenio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActividadConvenio", "ConvenioId", c => c.Int(nullable: false));
            AddColumn("dbo.Convenio", "Resolucion", c => c.String());
            AddColumn("dbo.Convenio", "Correlativo", c => c.String());
            AlterColumn("dbo.ActividadConvenio", "Avance", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ActividadConvenio", "Avance", c => c.Int(nullable: false));
            DropColumn("dbo.Convenio", "Correlativo");
            DropColumn("dbo.Convenio", "Resolucion");
            DropColumn("dbo.ActividadConvenio", "ConvenioId");
        }
    }
}
