using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FoodRecipes.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace FoodRecipes.Services.Implementations
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }
        public static IConfiguration config;

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        //public static async Task<RandomRecipe> GetJoke()
        //{
        //    var test2 = Startup.StaticConfig.GetConnectionString("RandomRecipeUrl");

        //    using (HttpResponseMessage response = await ApiClient.GetAsync(test2))
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {

        //            //dynamic value = await JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync());
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            dynamic obj = JsonConvert.DeserializeObject<dynamic>(result);

        //            var meal = JObject.Parse(result);
        //            var strMeal = (string)meal["meals"][0]["strMeal"];
        //            var strYoutube = (string)meal["meals"][0]["strYoutube"];

        //            RandomRecipe randomRecipe = new RandomRecipe() {
        //                Date = DateTime.Today,
        //                Name = strMeal,
        //                VideoLink = strYoutube
        //            };

        //            return randomRecipe;
        //        }
        //        else
        //        {
        //            throw new Exception();
        //        }
        //    }
        //}
    }
}
