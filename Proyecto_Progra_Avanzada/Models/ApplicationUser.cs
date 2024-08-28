using Microsoft.AspNetCore.Identity;

namespace Proyecto_Progra_Avanzada.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsOnline { get; set; }
    }
}
