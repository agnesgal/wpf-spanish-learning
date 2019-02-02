using System.Data.Entity;

namespace DataAccess
{
    public class WordDbContexts : DbContext
    {
        public WordDbContexts() : base("name=WordDbEntities") { }
        public DbSet<Word> Words { get; set; }
        public DbSet<Conjugation> Conjugations { get; set; }

    }
}
