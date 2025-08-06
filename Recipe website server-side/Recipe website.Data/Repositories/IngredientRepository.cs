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
    public class IngredientRepository : IIngredientRepository
    {
        private DataContext _context;
        public IngredientRepository(DataContext context)
        {
            _context = context;
        }

        //שליפת רכיבים
        public List<Ingredient> Get()
        {
            return _context.Ingredients.Include(i=>i.RecipeIngredients).ToList();
        }

        //הוספת רכיב
        public Ingredient AddIngredient(Ingredient ingredient)
        {
            var i = _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            return i.Entity;
        }
    }
}
