using System;
using System.Linq;
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
        public async Task<Recipe[]> SearchRecipe(string searchString)
        {
            var items = await _context.Recipe
                .Where(x=>x.Name.Contains(searchString))
                .ToArrayAsync();

            return items;
        }

        public async Task<Recipe> GetItemAsync( Guid recipeId)
        {
           return await _context.Recipe
                .Where(x => x.Id == recipeId)
                .FirstOrDefaultAsync();         
        }

        public async Task<bool> AddItemAsync(Recipe newRecipe)
        {
            newRecipe.Id = Guid.NewGuid();

            _context.Recipe.Add(newRecipe);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        public async Task<bool> UpdateItemAsync(Recipe updatedRecipe)
        {
            var item = await _context.Recipe
                .Where(x => x.Id == updatedRecipe.Id)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (item == null) return false;

             _context.Recipe.Update(updatedRecipe);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        public async Task<bool> DeleteItemAsync(Guid deleteRecipeId)
        {
            var item = await _context.Recipe
                .Where(x => x.Id == deleteRecipeId)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (item == null) return false;

            _context.Recipe.Remove(item);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
