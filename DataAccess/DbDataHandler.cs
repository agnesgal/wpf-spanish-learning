using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbDataHandler
    {
        private WordDbContexts WordDbContexts { get; set; }

        public DbDataHandler(WordDbContexts wordDbContexts)
        {
            WordDbContexts = wordDbContexts;
        }

        public Word SearchWord()
        {
            List<Word> words = WordDbContexts.Words.ToList();
            var random = new Random();
            int index = random.Next(words.Count);
            return words[index];
        }
    }
}
