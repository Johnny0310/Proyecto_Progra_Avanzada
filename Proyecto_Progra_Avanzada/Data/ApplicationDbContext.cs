using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_Progra_Avanzada.Models;
using System.Reflection.Emit;

namespace Proyecto_Progra_Avanzada.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reto> Retos { get; set; }
        public DbSet<MensajeChat> MensajesChat { get; set; }
        public DbSet<ParticipanteChat> ParticipantesChat { get; set; }

        public DbSet<AspNetRoles> AspNetRoles { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<Pokedex> Pokedex { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AspNetRoles>()
            .ToTable("AspNetRoles");

        }
    }
}
