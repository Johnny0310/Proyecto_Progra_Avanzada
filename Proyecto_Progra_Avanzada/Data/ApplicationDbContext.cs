using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_Avanzada.Models;

namespace Proyecto_Progra_Avanzada.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MensajeChat> MensajesChat { get; set; }
        public DbSet<ParticipanteChat> ParticipantesChat { get; set; }

        public DbSet<Pokedex> Pokedex { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Retos> Retos { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<TiposPokemon> TiposPokemon { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }
    }
}
