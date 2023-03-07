using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

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
            new SelectListItem { Value = Meal.Breakfast.ToString(), Text = Extensions.GetEnumDisplayName(Meal.Breakfast) },
            new SelectListItem { Value = Meal.Meats.ToString(), Text = Extensions.GetEnumDisplayName(Meal.Meats)},
            new SelectListItem { Value = Meal.Appetizers.ToString(), Text = Extensions.GetEnumDisplayName(Meal.Appetizers)},
            new SelectListItem { Value = Meal.Sides.ToString(), Text = Extensions.GetEnumDisplayName(Meal.Sides)},
        };

        [MaxLength(5000)]
        public string Instruction { get; set; }


    }
    public static class Extensions
    {
        public static string GetEnumDisplayName(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Name;
            else
                return value.ToString();
        }
    }
}