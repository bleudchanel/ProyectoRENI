namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnidadMedidaDescripcion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnidadMedida", "Descripcion", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnidadMedida", "Descripcion");
        }
    }
}
