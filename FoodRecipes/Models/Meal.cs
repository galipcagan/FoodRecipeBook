using System;
using System.ComponentModel;

namespace FoodRecipes.Models
{
    public enum Meal
    {
        [Description("Breakfast")]
        Breakfast = 1,
        [Description("Meats")]
        Meats = 2,
        [Description("Sides")]
        Sides = 3,
        [Description("Appetizers")]
        Appetizers = 4,
    }
}
