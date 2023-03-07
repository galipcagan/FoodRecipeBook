using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FoodRecipes.Models;
using FoodRecipes.Services.Implementations;
using FoodRecipes.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FoodRecipes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRecipeProcessor _recipeProcessor;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger,
            IRecipeProcessor recipeProcessor, IMemoryCache memoryCache)
        {
            _logger = logger;
            _recipeProcessor = recipeProcessor;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Api()
        {
            var item = await _recipeProcessor.GetRecipe();

            var model = new RandomRecipeViewModel()
            {
                 Items = item
            };

            return View(model);
        }
    }
}
