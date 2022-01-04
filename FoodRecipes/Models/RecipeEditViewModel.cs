using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodRecipes.Models
{
    public class RecipeEditViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<string> Ingredients { get; set; }

        public string MealType { get; set; }

        public List<SelectListItem> MealTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Meal Type 1" },
            new SelectListItem { Value = "2", Text = "Meal Type 2" },
            new SelectListItem { Value = "3", Text = "Meal Type 3"  },
        };

        [MaxLength(5000)]
        public string Instruction { get; set; }
    }
}
