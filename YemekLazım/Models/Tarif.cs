using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesiDeneme2.Models
{
    public class Tarif
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Açıklama { get; set; }
        public string? ResimUrl { get; set; }
        public ICollection<TarifMalzeme> TarifMalzemeler { get; set; }
    }
}
