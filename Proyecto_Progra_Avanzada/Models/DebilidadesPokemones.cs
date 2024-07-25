using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Progra_Avanzada.Models
{
    public class DebilidadesPokemones
    {
        [Key]
        public int PokemonID { get; set; }
        [Key]
        public int TipoID { get; set; }

        [ForeignKey("PokemonID")]
        public virtual Pokemon Pokemon { get; set; }

        [ForeignKey("TipoID")]
        public virtual TipoPokemon Tipo { get; set; }

    }
}
