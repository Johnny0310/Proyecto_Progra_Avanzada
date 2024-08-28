using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Proyecto_Progra_Avanzada.Models
{
    public class ParticipanteChat
    {
        public int ChatID { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; }

        public IdentityUser Usuario { get; set; }

        public DateTime FechaUnion { get; set; } = DateTime.Now;
    }
}