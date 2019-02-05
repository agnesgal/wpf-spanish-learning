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


            Conjugation comprar = new Conjugation("Compro", "Compras", "Compra", "Compramos", "Compráis", "Compran");
            Conjugation buscar = new Conjugation("Busco", "Buscas", "Busca", "Buscamos", "Buscáis", "Buscan");
            context.Conjugations.AddOrUpdate(comprar);
            context.Conjugations.AddOrUpdate(buscar);

            context.Words.AddOrUpdate(new Word("Kulcs", "La llave"));
            context.Words.AddOrUpdate(new Word("Sötét", "Oscura"));
            context.Words.AddOrUpdate(new Word("Hifitorony", "Cadena de música"));
            context.Words.AddOrUpdate(new Word("Akvárium halakkal", "Pecera con peces"));
            context.Words.AddOrUpdate(new Word("Fényes", "Luminoso"));
            context.Words.AddOrUpdate(new Word("Mellett", "Al lado del"));
            context.Words.AddOrUpdate(new Word("Kerek asztal lovagjai", "Los caballeros de la mesa redunda"));
            context.Words.AddOrUpdate(new Word("Lánc", "Cadena"));

            context.Words.AddOrUpdate(new Word("Vásárolni", "Comprar", comprar));
            context.Words.AddOrUpdate(new Word("Keresni", "Buscar", buscar));

            context.SaveChanges();
        }
    }
}
