using System;
using System.Threading.Tasks;
using FoodRecipes.Data;
using FoodRecipes.Models;
using Microsoft.EntityFrameworkCore;
namespace FoodRecipes.Services
{
    public class RecipeService : IRecipeItemService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Recipe[]> GetIncompleteItemsAsync()
        {
            var items = await _context.Recipe
            .ToArrayAsync();

            return items;
        }

        public async Task<bool> AddItemAsync(Recipe newRecipe)
        {
            newRecipe.Id = Guid.NewGuid();

            _context.Recipe.Add(newRecipe);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
