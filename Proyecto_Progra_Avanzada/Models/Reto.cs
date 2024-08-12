using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Proyecto_Progra_Avanzada.Models

{
    public class Reto
    {
        [Key]
        public int RetoID { get; set; }

        [ForeignKey("Retador")]
        public string RetadorID { get; set; }
        public IdentityUser Retador { get; set; }

        [ForeignKey("Retado")]
        public string RetadoID { get; set; }
        public IdentityUser Retado { get; set; }

        public DateTime FechaReto { get; set; }
        public string Estado { get; set; }
    }


}
