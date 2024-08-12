using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Proyecto_Progra_Avanzada.Models
{
    public class ParticipanteChat
    {
        [Key]
        public int ParticipanteID { get; set; }

        public int ChatID { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; }
        public IdentityUser Usuario { get; set; }
    }
}