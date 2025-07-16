using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BitirmeProjesiDeneme2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string? Adres { get; set; }
    }
}
