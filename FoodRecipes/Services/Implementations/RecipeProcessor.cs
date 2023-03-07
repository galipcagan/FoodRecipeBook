using System;
using System.Net.Http;
using System.Threading.Tasks;
using FoodRecipes.Models;
using FoodRecipes.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoodRecipes.Services.Implementations
{
    public class RecipeProcessor : IRecipeProcessor
    {
        public async Task<RandomRecipe> GetRecipe()
        {
            var test2 = Startup.StaticConfig.GetConnectionString("RandomRecipeUrl");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(test2))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    dynamic obj = JsonConvert.DeserializeObject<dynamic>(result);

                    var meal = JObject.Parse(result);
                    var strMeal = (string)meal["meals"][0]["strMeal"];
                    var strYoutube = (string)meal["meals"][0]["strYoutube"];

                    RandomRecipe randomRecipe = new RandomRecipe()
                    {
                        Date = DateTime.Today,
                        Name = strMeal,
                        VideoLink = strYoutube
                    };

                    return randomRecipe;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

    }
}
