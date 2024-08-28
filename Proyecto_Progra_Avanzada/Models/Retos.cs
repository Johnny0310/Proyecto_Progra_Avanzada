using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Progra_Avanzada.Models
{
    public class Retos
    {
        [Key]
        public int RetoID { get; set; }

        [ForeignKey("AspNetUsers")]
        public string RetadorID { get; set; }

        [ForeignKey("AspNetUsers")]
        public string RetadoID { get; set; }

        public DateTime FechaReto { get; set; }
        public string Ganador { get; set; }
    }
}
