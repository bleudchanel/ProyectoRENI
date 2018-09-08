namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodigosUpdateInsert : DbMigration
    {
        public override void Up()
        {
            Sql("Update ClaseConvenio SET Codigo='MAR' WHERE Id = 1");
            Sql("Update ClaseConvenio SET Codigo='ESP' WHERE Id = 2");
            Sql("Insert into AlcanceConvenio(Nombre,Descripcion,Activo,Codigo) VALUES('LOCAL', 'Alcance Local', 1, 'LOC')");
            Sql("Insert into AlcanceConvenio(Nombre,Descripcion,Activo,Codigo) VALUES('NACIONAL', 'Alcance Nacional', 1, 'NAC')");
            Sql("Insert into AlcanceConvenio(Nombre,Descripcion,Activo,Codigo) VALUES('INTERNACIONAL', 'Alcance Internacional', 1, 'INT')");
        }
        
        public override void Down()
        {
        }
    }
}
