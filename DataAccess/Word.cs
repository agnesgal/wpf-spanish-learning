using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    [Table("tblWord")]
    public class Word
    {
        public int Id { get; set; }

        [Required]
        public string HungarianWord { get; set; }

        [Required]
        public string SpanishWord { get; set; }

        public Conjugation Conjugation { get; set; }

        public Word(string hungarianWord, string spanishWord)
        {
            HungarianWord = hungarianWord;
            SpanishWord = spanishWord;
        }

        public Word(string hungarianWord, string spanishWord, Conjugation conjugation)
        {
            HungarianWord = hungarianWord;
            SpanishWord = spanishWord;
            Conjugation = conjugation;
        }

        public Word()
        {
        }
    }
}
