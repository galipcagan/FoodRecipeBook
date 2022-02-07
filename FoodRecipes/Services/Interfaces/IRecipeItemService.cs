using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodRecipes.Models;

namespace FoodRecipes.Services
{
    public interface IRecipeItemService
    {
        Task<Recipe[]> GetIncompleteItemsAsync();
        Task<Recipe[]> SearchRecipe(string searchText);
        Task<bool> AddItemAsync(Recipe newRecipe);
        Task<Recipe> GetItemAsync(Guid recipeId);
        Task<bool> UpdateItemAsync(Recipe updatedRecipe);
        Task<bool> DeleteItemAsync(Guid deletedRecipeId);

    }
}