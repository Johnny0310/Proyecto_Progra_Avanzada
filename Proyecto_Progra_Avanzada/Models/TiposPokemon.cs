using System.ComponentModel.DataAnnotations;

namespace Proyecto_Progra_Avanzada.Models
{
    public class TiposPokemon
    {
        [Key]
        public int tipoID { get; set; }
        public string nombre { get; set; }
    }
}
