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
        /// <returns>List of Pokemon in inventory</returns>
        public List<PokemonModel> GetInventory()
        {
            return _storeDAO.GetInventory();
        }

        /// <summary>
        /// Gets the current shopping cart
        /// </summary>
        /// <returns>List of Pokemon in the cart</returns>
        public List<PokemonModel> GetShoppingCart()
        {
            return _storeDAO.GetShoppingCart();
        }

        /// <summary>
        /// Gets a Pokemon by its ID
        /// </summary>
        /// <param name="pokemonId">ID of the Pokemon</param>
        /// <returns>Matching Pokemon object</returns>
        public PokemonModel GetPokemonById(int pokemonId)
        {
            return _storeDAO.GetPokemonById(pokemonId);
        }

        /// <summary>
        /// Adds a Pokemon to the inventory
        /// </summary>
        /// <param name="pokemon">Pokemon to add</param>
        /// <returns>Assigned ID of the added Pokemon</returns>
        public int AddPokemonToInventory(PokemonModel pokemon)
        {
            return _storeDAO.AddPokemonToInventory(pokemon);
        }

        /// <summary>
        /// Adds a Pokemon to the cart using its ID
        /// </summary>
        /// <param name="pokemonId">ID of the Pokemon to add</param>
        /// <returns>ID of the added Pokemon</returns>
        public int AddPokmemonToCart(int pokemonId)
        {
            return _storeDAO.AddPokemonToCart(pokemonId);
        }

        /// <summary>
        /// Writes the current inventory to storage
        /// </summary>
        /// <returns>True if write was successful</returns>
        public bool WriteInventory()
        {
            return _storeDAO.WriteInventory();
        }

        /// <summary>
        /// Reads inventory data from storage
        /// </summary>
        /// <returns>List of Pokemon from saved inventory</returns>
        public List<PokemonModel> ReadInventory()
        {
            return _storeDAO.ReadInventory();
        }

        /// <summary>
        /// Calculates total cost and clears the cart
        /// </summary>
        /// <returns>Total price of checkout</returns>
        public decimal Checkout()
        {
            return _storeDAO.Checkout();
        }

        /// <summary>
        /// Searches inventory by name or type
        /// </summary>
        /// <param name="query">Search keyword</param>
        /// <returns>List of matching Pokemon</returns>
        public List<PokemonModel> SearchInventory(string query)
        {
            return _storeDAO.SearchInventory(query);
        }
    }
}
