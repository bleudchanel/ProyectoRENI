namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameConvention : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Convenios", newName: "Convenio");
            RenameTable(name: "dbo.Indicadors", newName: "Indicador");
            RenameTable(name: "dbo.UnidadMedidas", newName: "UnidadMedida");
            RenameTable(name: "dbo.Proponentes", newName: "Proponente");
            RenameTable(name: "dbo.Dependencias", newName: "Dependencia");
            RenameTable(name: "dbo.Solicitantes", newName: "Solicitante");
            RenameTable(name: "dbo.Documentoes", newName: "Documento");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Documento", newName: "Documentoes");
            RenameTable(name: "dbo.Solicitante", newName: "Solicitantes");
            RenameTable(name: "dbo.Dependencia", newName: "Dependencias");
            RenameTable(name: "dbo.Proponente", newName: "Proponentes");
            RenameTable(name: "dbo.UnidadMedida", newName: "UnidadMedidas");
            RenameTable(name: "dbo.Indicador", newName: "Indicadors");
            RenameTable(name: "dbo.Convenio", newName: "Convenios");
        }
    }
}
