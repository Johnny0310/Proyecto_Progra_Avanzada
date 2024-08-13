using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Progra_Avanzada.Models
{
    public class Pokemon
    {
        [Key]
        public int pokemonID { get; set; }
        public int numeroEvolucion { get; set; }
        public string nombre { get; set; }
        public string debilidad { get; set; }
        [ForeignKey("TiposPokemon")]
        public int tipoID { get; set; }
        public float peso { get; set; }
    }
}
