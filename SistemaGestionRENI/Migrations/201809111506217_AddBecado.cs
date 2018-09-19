namespace SistemaGestionRENI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBecado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movilidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Anio = c.Int(nullable: false),
                        Semestre = c.String(maxLength: 20),
                        NombresApellidos = c.String(maxLength: 150),
                        Sexo = c.String(maxLength: 1),
                        Nacionalidad = c.String(maxLength: 50),
                        Edad = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Direccion = c.String(maxLength: 200),
                        TipoDocumento = c.String(maxLength: 15),
                        NumeroDocumento = c.String(maxLength: 20),
                        Telefono = c.String(maxLength: 20),
                        Email = c.String(maxLength: 50),
                        Facebook = c.String(maxLength: 50),
                        DatosContacto = c.String(maxLength: 250),
                        Universidad = c.String(maxLength: 250),
                        DirUniversidad = c.String(maxLength: 250),
                        UnidadAcad = c.String(maxLength: 250),
                        Carrera = c.String(maxLength: 250),
                        AnioSemestre = c.String(maxLength: 150),
                        CoordinadorLocal = c.String(maxLength: 250),
                        Celular = c.String(maxLength: 50),
                        Skype = c.String(maxLength: 150),
                        Promedio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Aclaración = c.String(maxLength: 250),
                        FechaRegistro = c.DateTime(nullable: false),
                        LugarRegistro = c.String(maxLength: 250),
                        ProgramaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programa", t => t.ProgramaId, cascadeDelete: true)
                .Index(t => t.ProgramaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movilidad", "ProgramaId", "dbo.Programa");
            DropIndex("dbo.Movilidad", new[] { "ProgramaId" });
            DropTable("dbo.Movilidad");
        }
    }
}
