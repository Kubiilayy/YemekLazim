using BitirmeProjesiDeneme2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesiDeneme2.Utility
{
    public class UygulamaDbContext : IdentityDbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }
        public DbSet<Tarif> Tarifler { get; set; }
        public DbSet<Malzeme> Malzemeler { get; set; }
        public DbSet<TarifMalzeme> TarifMalzemeleri { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
