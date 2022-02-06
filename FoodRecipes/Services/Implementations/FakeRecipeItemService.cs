using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodRecipes.Services;
using FoodRecipes.Models;

namespace FoodRecipes.Services
{
    public class FakeRecipeItemService :IRecipeItemService
    {
        public Task<bool> AddItemAsync(Recipe newRecipe)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe[]> GetIncompleteItemsAsync()
        {
            var item1 = new Recipe
            {
                Name = "Lasagna",
                Ingredients = new List<string> { "salt", "pepper" },
                Instruction = "Something something",
                MealType = "1",
            };

            var item2 = new Recipe
            {
                Name = "Chicken Parm",
                Ingredients = new List<string> { "salt", "pepper" },
                Instruction = "Something something",
                MealType = "1",
            };

            return Task.FromResult(new[] { item1, item2 });
        }

        public Task<Recipe> GetItemAsync(Guid recipeId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateItemAsync(Recipe updatedRecipe)
        {
            throw new NotImplementedException();
        }
    }
}
