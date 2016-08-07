namespace SisPrestamo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updating : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Prestamos", newName: "Prestamos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Prestamos", newName: "Prestamoes");
        }
    }
}
