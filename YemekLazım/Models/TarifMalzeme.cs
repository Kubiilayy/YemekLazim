using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesiDeneme2.Models
{
    public class TarifMalzeme
    {
        [Key]
        public int Id { get; set; }
        public int TarifId { get; set; }
        public Tarif Tarif { get; set; }
        public int MalzemeId { get; set; }
        public Malzeme Malzeme { get; set; }
        
    }
}
