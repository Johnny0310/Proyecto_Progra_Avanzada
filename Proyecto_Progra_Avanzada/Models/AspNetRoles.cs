using System.ComponentModel.DataAnnotations;

namespace Proyecto_Progra_Avanzada.Models
{
    public class AspNetRoles
    {
        [Key]
        public string RoleId { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
