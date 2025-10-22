using PokemonClassLibrary.Models;
using PokemonClassLibrary.Services.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary.Services.BusinessLogicLayer
{
    /// <summary>
    /// Handles bussiness logic for the Pokemon store
    /// </summary>
    public class StoreLogic
    {
        /// <summary>
        /// Data access object for inventory operations
        /// </summary>
        private StoreDAO _storeDAO;

        /// <summary>
        /// Initializes the store logic with a DAO instance.
        /// </summary>
        public StoreLogic()
        {
            _storeDAO = new StoreDAO();
        }

        /// <summary>
        /// Gets the current Pokemon inventory
        /// </summary>
        /// <returns></returns>
        public List<PokemonModel> GetInventory()
        {
            return _storeDAO.GetInventory();
        }

        /// <summary>
        /// Adds a Pokemon to the inventory
        /// </summary>
        /// <param name="pokemon"></param>
        /// <returns></returns>
        public int AddPokemonToInventory(PokemonModel pokemon)
        {
            return _storeDAO.AddPokemonToInventory(pokemon);
        }
    }
}
