namespace SisPrestamo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prestamos", "Cliente_id", "dbo.Clientes");
            DropForeignKey("dbo.Prestamos", "tipo_prestamo1_id", "dbo.tipo_prestamo");
            DropIndex("dbo.Prestamos", new[] { "Cliente_id" });
            DropIndex("dbo.Prestamos", new[] { "tipo_prestamo1_id" });
            RenameColumn(table: "dbo.Prestamos", name: "Cliente_id", newName: "ClienteId");
            RenameColumn(table: "dbo.Prestamos", name: "tipo_prestamo1_id", newName: "tipo_prestamoId");
            AlterColumn("dbo.Prestamos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Prestamos", "Importe", c => c.Int(nullable: false));
            AlterColumn("dbo.Prestamos", "Tasa", c => c.Int(nullable: false));
            AlterColumn("dbo.Prestamos", "Plazo", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.Prestamos", new[] { "id" });
            AddPrimaryKey("dbo.Prestamos", "Id");
            AddForeignKey("dbo.Prestamos", "ClienteId", "dbo.Clientes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Prestamos", "tipo_prestamoId", "dbo.tipo_prestamo", "id", cascadeDelete: true);
            CreateIndex("dbo.Prestamos", "ClienteId");
            CreateIndex("dbo.Prestamos", "tipo_prestamoId");
            DropColumn("dbo.Prestamos", "id_cliente");
            DropColumn("dbo.Prestamos", "tipo_prestamo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prestamos", "tipo_prestamo", c => c.Int());
            AddColumn("dbo.Prestamos", "id_cliente", c => c.Int(nullable: false));
            DropIndex("dbo.Prestamos", new[] { "tipo_prestamoId" });
            DropIndex("dbo.Prestamos", new[] { "ClienteId" });
            DropForeignKey("dbo.Prestamos", "tipo_prestamoId", "dbo.tipo_prestamo");
            DropForeignKey("dbo.Prestamos", "ClienteId", "dbo.Clientes");
            DropPrimaryKey("dbo.Prestamos", new[] { "Id" });
            AddPrimaryKey("dbo.Prestamos", "id");
            AlterColumn("dbo.Prestamos", "Plazo", c => c.DateTime());
            AlterColumn("dbo.Prestamos", "Tasa", c => c.Int());
            AlterColumn("dbo.Prestamos", "Importe", c => c.Int());
            AlterColumn("dbo.Prestamos", "id", c => c.Int(nullable: false, identity: true));
            RenameColumn(table: "dbo.Prestamos", name: "tipo_prestamoId", newName: "tipo_prestamo1_id");
            RenameColumn(table: "dbo.Prestamos", name: "ClienteId", newName: "Cliente_id");
            CreateIndex("dbo.Prestamos", "tipo_prestamo1_id");
            CreateIndex("dbo.Prestamos", "Cliente_id");
            AddForeignKey("dbo.Prestamos", "tipo_prestamo1_id", "dbo.tipo_prestamo", "id");
            AddForeignKey("dbo.Prestamos", "Cliente_id", "dbo.Clientes", "id");
        }
    }
}
