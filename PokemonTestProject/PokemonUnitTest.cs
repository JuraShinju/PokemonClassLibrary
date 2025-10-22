using PokemonClassLibrary.Models;
using PokemonClassLibrary.Services.BusinessLogicLayer;
using System.Data;

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

        /// <summary>
        /// Test to verify that a Pokemon is added to the cart when a valid ID is provided
        /// </summary>
        [Fact]
        public void AddPokemonToCart_ShouldAddPokemon_WhenPokemonIdIsGiven()
        {
            // Create store logic instance
            StoreLogic store = new StoreLogic();

            // Create a Pokemon object
            PokemonModel pokemon = new PokemonModel()
            {
                Id = 1,
                Name = "Charmander",
                Type = "Fire-type",
                Price = 1000m
            };

            // Add Pokemon to inventory
            store.AddPokemonToInventory(pokemon);
            // Add Pokemon to cart using its ID
            int result = store.AddPokemonToCart(pokemon.Id);
            // Get current shopping cart
            List<PokemonModel> cart = store.GetShoppingCart();
            // Assert that returned ID matches expected
            Assert.Equal(1, result);
            // Assert that cart contains the added Pokemon
            Assert.Contains(cart, verify => verify.Id == pokemon.Id);
        }

        /// <summary>
        /// Test to verify that checkout returns the correct total and clears the cart.
        /// </summary>
        [Fact]
        public void Checkout_ShouldReturnCorrectTotal_AndClearCart()
        {
            // Create store logic instance
            StoreLogic store = new StoreLogic();

            // Create first Pokemon
            PokemonModel pokemon1 = new PokemonModel()
            {
                Id = 1,
                Name = "Squirtle",
                Type = "Water-type",
                Price = 700m
            };

            // Create second Pokemon
            PokemonModel pokemon2 = new PokemonModel()
            {
                Id = 2,
                Name = "Dragonite",
                Type = "Dragon-type",
                Price = 2000m
            };

            // Add both Pokemon to inventory
            store.AddPokemonToInventory(pokemon1);
            store.AddPokemonToInventory(pokemon2);

            // Add both Pokemon to cart
            store.AddPokemonToCart(pokemon1.Id);
            store.AddPokemontoCart(pokemon2.Id);

            // Perform checkout
            decimal total = store.Checkout();

            // Get cart after checkout
            List<PokemonModel> cartAfterCheckout = store.GetShoppingCart();

            // Assert total is within expected range
            Assert.True(total >= (pokemon1.Price + pokemon2.Price) * 0.95m);
            Assert.True(total <= (pokemon1.Price + pokemon2.Price) * 1.05m);

            // Assert cart is cleared
            Assert.Empty(cartAfterCheckout);
        }
    }
}