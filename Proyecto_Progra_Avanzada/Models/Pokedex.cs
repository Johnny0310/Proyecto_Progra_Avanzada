using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Progra_Avanzada.Models
{
    public class Pokedex
    {
        [Key]
        public int id_Pokedex { get; set; }
        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }
        [ForeignKey("Pokemon")]
        public int PokemonID { get; set; }

        public DateTime fecha_captura { get; set; }
    }
}
