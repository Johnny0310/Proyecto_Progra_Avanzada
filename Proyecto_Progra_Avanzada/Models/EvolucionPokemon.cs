using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Progra_Avanzada.Models
{
    public class EvolucionPokemon
    {
        [Key]
        public int PokemonBaseID { get; set; }
        [Key]
        public int PokemonEvolucionado {  get; set; }
        public int NivelEvolucion { get; set; }

        [ForeignKey("PokemonBaseID")]
        public virtual Pokemon Pokemon { get; set; }

        [ForeignKey("PokemonEvolucionado")]


        public virtual Pokemon PokemonEvolucion { get; set; }


    }
}
