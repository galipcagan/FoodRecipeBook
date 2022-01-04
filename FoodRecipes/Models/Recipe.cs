using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodRecipes.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<string> Ingredients { get; set; }

        public string MealType { get; set; }

        public string Instruction { get; set; }
    }
}
