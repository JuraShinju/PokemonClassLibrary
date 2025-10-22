using PokemonClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary.Services.DataAccessLayer
{
    /// <summary>
    /// Handles data access for Pokemon store inventory.
    /// </summary>
    public class StoreDAO
    {
        /// <summary>
        /// List to store Pokemon items.
        /// </summary>
        private List<PokemonModel> _inventory;

        /// <summary>
        /// Initializes the inventory list
        /// </summary>
        public StoreDAO()
        {
            _inventory = new List<PokemonModel>();
        }

        /// <summary>
        /// Returns the current inventory list.
        /// </summary>
        /// <returns></returns>
        public List<PokemonModel> GetInventory()
        {
            return _inventory;
        }

        /// <summary>
        /// Adds a Pokemon to the inventory and assigns an ID
        /// </summary>
        /// <param name="pokemon"></param>
        /// <returns></returns>
        public int AddPokemonToInventory(PokemonModel pokemon)
        {
            // Set ID based on current inventory count
            pokemon.Id = _inventory.Count + 1;
            // Add Pokemon to inventory
            _inventory.Add(pokemon);
            // Return the assigned ID
            return pokemon.Id;
        }
    }
}
