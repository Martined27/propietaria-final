namespace SisPrestamo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatingTables : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Cedula = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Prestamos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_cliente = c.Int(nullable: false),
                        Importe = c.Int(),
                        Tasa = c.Int(),
                        Plazo = c.DateTime(),
                        tipo_prestamo = c.Int(),
                        Cliente_id = c.Int(),
                        tipo_prestamo1_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_id)
                .ForeignKey("dbo.tipo_prestamo", t => t.tipo_prestamo1_id)
                .Index(t => t.Cliente_id)
                .Index(t => t.tipo_prestamo1_id);
            
            CreateTable(
                "dbo.tipo_prestamo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tipo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Prestamoes", new[] { "tipo_prestamo1_id" });
            DropIndex("dbo.Prestamoes", new[] { "Cliente_id" });
            DropForeignKey("dbo.Prestamoes", "tipo_prestamo1_id", "dbo.tipo_prestamo");
            DropForeignKey("dbo.Prestamoes", "Cliente_id", "dbo.Clientes");
            DropTable("dbo.tipo_prestamo");
            DropTable("dbo.Prestamoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.UserProfile");
        }
    }
}
