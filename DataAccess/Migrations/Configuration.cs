namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.WordDbContexts>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.WordDbContexts context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [tblWord]");


            Conjugation comprar = new Conjugation("compro", "compras", "compra", "compramos", "compráis", "compran");
            Conjugation buscar = new Conjugation("busco", "buscas", "busca", "buscamos", "buscáis", "buscan");
            context.Conjugations.AddOrUpdate(comprar);
            context.Conjugations.AddOrUpdate(buscar);

            context.Words.AddOrUpdate(new Word("Kulcs", "La llave"));
            context.Words.AddOrUpdate(new Word("Vásárolni", "Comprar", comprar));
            context.Words.AddOrUpdate(new Word("Keresni", "Buscar", buscar));

            context.SaveChanges();
        }
    }
}
