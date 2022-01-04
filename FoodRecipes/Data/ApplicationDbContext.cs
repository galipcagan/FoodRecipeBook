using System;
using Microsoft.EntityFrameworkCore;
using FoodRecipes.Models;
using Microsoft.AspNetCore.Identity;



namespace FoodRecipes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Recipe> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // ...
        }
    }
}
