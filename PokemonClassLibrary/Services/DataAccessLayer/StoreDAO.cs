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
        /// Holds the list of Pokemon currently added to the shopping cart.
        /// </summary>
        private List<PokemonModel> _shoppingCart;

        /// <summary>
        /// Directory name where inventory data will be stored.
        /// </summary>
        private string _fileDirectory = "Data";

        /// <summary>
        /// Name of the text file used to store inventory data.
        /// </summary>
        private string _textFile = "inventory.txt";

        /// <summary>
        /// Full file path combining base directory, folder, and file name.
        /// </summary>
        private string _filePath;

        /// <summary>
        /// Initializes the store DAO by setting up inventory, cart, and file path.
        /// </summary>
        public StoreDAO()
        {
            // Create empty inventory list
            _inventory = new List<PokemonModel>();

            // Create empty shopping cart list
            _shoppingCart = new List<PokemonModel>();

            // Build full file path for inventory storage
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileDirectory, _textFile);
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
        /// Returns the current list of Pokemon in the shopping cart.
        /// </summary>
        /// <returns>List of Pokemon currently in the cart</returns>
        public List<PokemonModel> GetShoppingCart()
        {
            return _shoppingCart;
        }

        /// <summary>
        /// Searches the inventory for a Pokemon by its ID.
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public PokemonModel GetPokemonById(int pokemonId)
        {
            // Loop through inventory
            for (int i = 0; i < _inventory.Count; i++)
            {
                // Check if ID matches
                if (_inventory[i].Id == pokemonId)
                {
                    // Return matching Pokemon
                    return _inventory[i];
                }
            }

            // Return null if not found
            return null!;
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

        /// <summary>
        /// Adds a Pokemon to the shopping cart by matching its ID.
        /// </summary>
        /// <param name="pokemonId">ID of the Pokemon to add</param>
        /// <returns>Total number of items in the cart after addition</returns>
        public int AddPokemonToCart(int pokemonId)
        {
            // Loop through inventory to find matching ID
            for (int i = 0; i < _inventory.Count; i++)
            {
                // If ID matches add to cart
                if (_inventory[i].Id == pokemonId)
                {
                    _shoppingCart.Add(_inventory[i]);
                }
            }

            // Return updated cart count
            return _shoppingCart.Count;
        }

        /// <summary>
        /// Writes the current inventory to a file. Creates the directory if it doesn't exist
        /// </summary>
        /// <returns>True if write succeeds; false if an error occurs</returns>
        public bool WriteInventory()
        {
            // Check if directory exists
            if (!Directory.Exists(_fileDirectory))
            {
                // Create directory if missing
                Directory.CreateDirectory(_fileDirectory);
            }

            try
            {
                // Open file for writing
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    // Write each Pokemon to file
                    foreach (PokemonModel pokemon in _inventory)
                    {
                        //
                        writer.WriteLine($"Pokemon, {pokemon.Name}, {pokemon.Type}, {pokemon.Price}");
                    }
                }

                // Write successful
                return true;
            }
            catch
            {
                // Write failed
                return false;
            }
        }

        /// <summary>
        /// Reads Pokemon inventory data from a text file and loads it into memory.
        /// </summary>
        /// <returns>List of Pokemon loaded into the inventory</returns>
        public List<PokemonModel> ReadInventory()
        {
            // Line buffer
            string? line = "";

            // Split parts of each line
            string[] parts = [];

            // Temporary variables for Pokemon data
            string name = "", type = "";
            decimal price = 0m;

            try
            {
                // Check if file exists
                if (File.Exists(_filePath))
                {
                    // Open file for reading
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        // Read each line
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Split line into parts
                            parts = line.Split(", ");

                            // Extract values
                            name = parts[1];
                            type = parts[2];
                            price = ParseDecimal(parts[3]);

                            // Create Pokemon and add to inventory
                            PokemonModel pokemon = new PokemonModel(0, name, type, price);
                            AddPokemonToInventory(pokemon);
                        }
                    }
                }
            }
            catch
            {
                // Return current inventory if read fails
                return _inventory;
            }

            // Return loaded inventory
            return _inventory;
        }

        /// <summary>
        /// Safely parses a string into a decimal. Returns 0 if parsing fails.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private decimal ParseDecimal(string input)
        {
            try
            {
                // Try to parse input
                return decimal.Parse(input);
            }
            catch
            {
                // Return 0 if parsing fails
                return 0m;
            }
        }

        /// <summary>
        /// Calculates the total price of all Pokemon in the cart and clears the cart.
        /// </summary>
        /// <returns>Total cost of the checkout</returns>
        public decimal Checkout()
        {
            // Initialize total
            decimal total = 0m;

            // Sum prices of all Pokemon in the cart
            foreach (PokemonModel pokemon in _shoppingCart)
            {
                total += pokemon.Price;
            }

            // Clear the cart after checkout
            _shoppingCart.Clear();

            // Return the final total
            return total;
        }

        /// <summary>
        /// Searches inventory for Pokemon with a matching name (case-insensitive)
        /// </summary>
        /// <param name="searchCriteria">Name to search for</param>
        /// <returns>List of matching Pokemon</returns>
        public List<PokemonModel> SearchInventory(string searchCriteria)
        {
            // List to hold search results
            List<PokemonModel> searchResults = new List<PokemonModel>();

            // Loop through inventory
            foreach (PokemonModel pokemon in _inventory)
            {
                // Check if name matches (case-insensitive)
                if (pokemon.Name.ToLower() == searchCriteria.ToLower())
                {
                    // Add match to results
                    searchResults.Add(pokemon);
                }
            }

            // Return all matches
            return searchResults;
        }
    }
}
