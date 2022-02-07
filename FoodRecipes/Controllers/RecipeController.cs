using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FoodRecipes.Models;
using FoodRecipes.Services;

namespace FoodRecipes.Controllers
{
    public class RecipeController: Controller
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeItemService _recipeItemService;


        public RecipeController(IRecipeItemService recipeItem)
        {
            _recipeItemService = recipeItem;
        }

        public async Task<IActionResult> Index()
        {
            var item = await _recipeItemService.GetIncompleteItemsAsync();
            var model = new RecipeViewModel()
            {
                Items = item
            };

            return View(model);
        }

        public IActionResult AddEditIndex()
        {
            var model = new RecipeEditViewModel();
            return View(model);
        }
        public async Task<IActionResult> ViewEdit(Guid recipeId)
        {
            var item = await _recipeItemService.GetItemAsync(recipeId);
            var model = new RecipeEditViewModel()
            {
                 Id = item.Id,
                 Ingredients = item.Ingredients,
                 MealType = item.MealType,
                 Name = item.Name,
                 Instruction = item.Instruction
            };

            return View(model);
        }
        public async Task<IActionResult> DeleteRecipe(Guid deletedRecipeId)
        {
            var succesfull = await _recipeItemService.DeleteItemAsync(deletedRecipeId);
            if (!succesfull)
            {
                return BadRequest("Could not delete recipe");
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AddRecipe(Recipe newRecipe)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var succesfull = await _recipeItemService.AddItemAsync(newRecipe);
            if (!succesfull)
            {
                return BadRequest("Could not add recipe");
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateRecipe(Recipe updatedRecipe)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var succesfull = await _recipeItemService.UpdateItemAsync(updatedRecipe);
            if (!succesfull)
            {
                return BadRequest("Could not update recipe");
            }

            return RedirectToAction("ViewEdit", new {recipeId = updatedRecipe.Id});
        }

        public async Task<IActionResult> ViewIndex()
        {
            var item = await _recipeItemService.GetIncompleteItemsAsync();
            var model = new RecipeViewModel()
            {
                Items = item
            };

            return View(model);
        }

        public async Task<IActionResult> SearchRecipe(string searchString)
        {
            var item = await _recipeItemService.SearchRecipe(searchString);
            var model = new RecipeViewModel()
            {
                Items = item
            };

            return View("Index", model);
        }
    }
}
