using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Progra_Avanzada.Models
{
    public class TipoPokemon
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoID { get; set; }
        public String Nombre { get; set; }

        public virtual ICollection<Pokemon> Pokemones { get; set; }
        public virtual ICollection <DebilidadesPokemones> DebilidadesPokemones { get; set; }
    }
}
