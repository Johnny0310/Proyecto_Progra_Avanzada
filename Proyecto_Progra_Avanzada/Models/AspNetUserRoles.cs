using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Progra_Avanzada.Models
{
    public class AspNetUserRoles
    {
        [Key]
        public string UserId { get; set; }

        [ForeignKey("AspNetRoles")]
        public string RoleId { get; set; }
    }
}
