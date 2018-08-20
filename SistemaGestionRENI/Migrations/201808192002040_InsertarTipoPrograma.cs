namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertarTipoPrograma : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TipoPrograma(Nombre,Activo) VALUES('Entrante Estudiantil',1)");
            Sql("INSERT INTO TipoPrograma(Nombre,Activo) VALUES('Salida Estudiantil',1)");
            Sql("INSERT INTO TipoPrograma(Nombre,Activo) VALUES('Entrante Docente',1)");
            Sql("INSERT INTO TipoPrograma(Nombre,Activo) VALUES('Salida Docente',1)");
            Sql("INSERT INTO TipoPrograma(Nombre,Activo) VALUES('Entrante Administrativo',1)");
            Sql("INSERT INTO TipoPrograma(Nombre,Activo) VALUES('Salida Administrativo',1)");
        }
        
        public override void Down()
        {
        }
    }
}
