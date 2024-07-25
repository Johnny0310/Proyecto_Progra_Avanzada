using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Progra_Avanzada.Models
{
    public class Pokemon
    {
        
            [Key]

            public int PokemonID { get; set; }
            public int Numero { get; set; }
            public String Nombre { get; set; }
            public double Peso {  get; set; }
            public double Altura { get; set; }
            public String Descripcion {  get; set; }

            public int TipoID { get; set; }

        [ForeignKey("TipoID")]

        //La palabra virtual permite que la propiedad sea sobreescrita dentro de una clase derivada 
        public virtual TipoPokemon TipoPokemon { get; set; }

        public virtual ICollection<DebilidadesPokemones> DebilidadesPokemones { get; set; }


     



        
    }
}
