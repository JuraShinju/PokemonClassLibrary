using PokemonClassLibrary.Models;
using PokemonClassLibrary.Services.BusinessLogicLayer;

namespace PokemonTestProject
{
    /// <summary>
    /// Unit test for StoreLogic class.
    /// </summary>
    public class PokemonUnitTest
    {
        /// <summary>
        /// Tests if adding a Pokemon increases inventory count.
        /// </summary>
        [Fact]
        public void AddPokemonToInventory_ShouldIncreaseInventoryCount()
        {
            // Create a new store instance
            StoreLogic store = new StoreLogic();

            // Create a new Pokemon object
            PokemonModel pokemon = new PokemonModel()
            {
                Id = 1,
                Name = "Pikachu",
                Type = "Electric-type",
                Price = 350m
            };

            // Add Pokemon to store inventory
            store.AddPokemonToInventory(pokemon);
            // Get current inventory list
            List<PokemonModel> inventory = store.GetInventory();
            // Check if inventory contains the added Pokemon
            Assert.Contains(pokemon, inventory);
        }

        /// <summary>
        /// Test to check if inventory is empty when no Pokemon is added.
        /// </summary>
        [Fact]
        public void GetInventory_ShouldReturnEmptyList_WhenNoPokmenIsAdded()
        {
            // Create store logic instance
            StoreLogic store = new StoreLogic();
            // Get current inventory
            List<PokemonModel> inventory = store.GetInventory();
            // Assert that inventory is emtpy
            Assert.Empty(inventory);
        }
    }
}