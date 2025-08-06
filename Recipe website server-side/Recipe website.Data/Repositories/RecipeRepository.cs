using Microsoft.EntityFrameworkCore;
using Recipe_website.Core.Repositories_Interface;
using Recipe_website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_website.Data.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private DataContext _context;
        public RecipeRepository(DataContext context)
        {
            _context = context;
        }

        //שליפת כל המתכונים
        public List<Recipe> Get()
        {
            return _context.Recipes.Include(r => r.RecipeIngredients).ToList();
           // return _context.Recipes.ToList();

        }      
        
        //שליפת מתכון לפי קוד מתכון
        public Recipe GetRecipe(int RecipeId) 
        {
            return _context.Recipes.Include(r => r.RecipeIngredients).FirstOrDefault(r => r.RecipeId == RecipeId);
           // return _context.Recipes.FirstOrDefault(r => r.RecipeId == RecipeId);

        }

        //הוספת מתכון
        public Recipe AddRecipe(Recipe recipe)
        {
            var r=_context.Recipes.Add(recipe);
            _context.SaveChanges();
            return r.Entity;
        }
       
    }
}
