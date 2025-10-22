using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary.Models
{
    /// <summary>
    /// Represents a Pokemon with basic properties.
    /// </summary>
    public class PokemonModel
    {
        /// <summary>
        /// Unique ID of the Pokemon.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Pokemon.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of the Pokemon (e.g., Fire, Water).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Price or value of the Pokemon.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Deafault constructor sets default values
        /// </summary>
        public PokemonModel()
        {
            Id = 0;
            Name = "Unknown";
            Type = "Unknown";
            Price = 0.0M;
        }

        /// <summary>
        /// Constructor to initialize with specific values.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        public PokemonModel(int id, string name, string type, decimal price)
        {
            Id = id;
            Name = name;
            Type = type;
            Price = price;
        }

        /// <summary>
        /// Returns a formatted string with Pokemon details.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: {1} {2} - {3:C2}", Id, Name, Type, Price);
        }
    }
}
