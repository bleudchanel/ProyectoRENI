namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConvenioPropExt : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Convenio", name: "ProponenteExtId", newName: "ProponenteExternoId");
            RenameIndex(table: "dbo.Convenio", name: "IX_ProponenteExtId", newName: "IX_ProponenteExternoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Convenio", name: "IX_ProponenteExternoId", newName: "IX_ProponenteExtId");
            RenameColumn(table: "dbo.Convenio", name: "ProponenteExternoId", newName: "ProponenteExtId");
        }
    }
}
