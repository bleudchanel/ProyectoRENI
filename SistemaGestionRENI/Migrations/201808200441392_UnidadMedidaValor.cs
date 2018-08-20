namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnidadMedidaValor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnidadMedida", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnidadMedida", "Valor");
        }
    }
}
