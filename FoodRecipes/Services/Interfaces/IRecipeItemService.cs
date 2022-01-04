using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodRecipes.Models;

namespace FoodRecipes.Services
{
    public interface IRecipeItemService
    {
        Task<Recipe[]> GetIncompleteItemsAsync();
        Task<bool> AddItemAsync(Recipe newRecipe);

    }
}