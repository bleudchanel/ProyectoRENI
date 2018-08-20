namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndicadorValor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Indicador", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.UnidadMedida", "Valor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UnidadMedida", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Indicador", "Valor");
        }
    }
}
