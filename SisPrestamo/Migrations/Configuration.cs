namespace SisPrestamo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SisPrestamo.Models.SisPrestamoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SisPrestamo.Models.SisPrestamoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Clientes.AddOrUpdate(
              c => c.Nombre,
              new Cliente { Nombre = "Efrain", Apellido = "Toribio Reyes", Cedula = "403-2354134-3" },
              new Cliente { Nombre = "Martin", Apellido = "Edmundo", Cedula = "341-3525352-6" },
              new Cliente { Nombre = "Maria", Apellido = "Castillo", Cedula = "452-5235235-7" }
            );

        }
    }
}
