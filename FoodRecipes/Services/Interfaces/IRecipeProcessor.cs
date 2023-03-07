using System;
using System.Threading.Tasks;
using FoodRecipes.Models;

namespace FoodRecipes.Services.Interfaces
{
    public interface IRecipeProcessor
    {
        Task<RandomRecipe> GetRecipe();
    }
}
