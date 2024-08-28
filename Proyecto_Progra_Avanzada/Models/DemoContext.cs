using Microsoft.EntityFrameworkCore;

namespace Proyecto_Progra_Avanzada.Models
{
    class DemoContext : DbContext
    {
        string DBJohnny = "Server=DESKTOP-N9KIN1T\\SQLEXPRESS;Database=db_Poryecto_Progra_Avanzada;Trusted_Connection=True;TrustServerCertificate=True;";
        string DBWayner = "Server=LAPTOP-WAYNER;Database=db_Snake_Game;Trusted_Connection=True;TrustServerCertificate=True;";
        public DemoContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@DBJohnny);
            }
        }

        public DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<AspNetRoles> AspNetRoles { get; set; }
        public DbSet<Pokedex> Pokedex { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<TiposPokemon> TiposPokemon { get; set; }

    }
}
