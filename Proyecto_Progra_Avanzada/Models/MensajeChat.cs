using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Progra_Avanzada.Models
{
    public class MensajeChat
    {
        [Key]
        public int MensajeChatID { get; set; }
        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; }
        public IdentityUser Usuario { get; set; }
        public int ChatID { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}