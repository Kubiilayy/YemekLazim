using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesiDeneme2.Models
{
    public class Malzeme
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public ICollection<TarifMalzeme> TarifMalzemeler { get; set; }
    }
}
