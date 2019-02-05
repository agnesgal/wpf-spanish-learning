using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    [Table("tblConjugation")]
    public class Conjugation
    {
        public int Id { get; set; }

        [Required]
        public string FirstPersonSingular { get; set; }

        [Required]
        public string SecondPersonSingular { get; set; }

        [Required]
        public string ThirdPersonSingular { get; set; }

        [Required]
        public string FirstPersonPlural { get; set; }

        [Required]
        public string SecondPersonPlural { get; set; }

        [Required]
        public string ThirdPersonPlural { get; set; }

        public Conjugation(string firstPersonSingular, string secondPersonSingular, string thirdPersonSingular, string firstPersonPlural, string secondPersonPlural, string thirdPersonPlural)
        {
            FirstPersonSingular = firstPersonSingular;
            SecondPersonSingular = secondPersonSingular;
            ThirdPersonSingular = thirdPersonSingular;
            FirstPersonPlural = firstPersonPlural;
            SecondPersonPlural = secondPersonPlural;
            ThirdPersonPlural = thirdPersonPlural;
        }

        public Conjugation()
        {
        }
    }
}
