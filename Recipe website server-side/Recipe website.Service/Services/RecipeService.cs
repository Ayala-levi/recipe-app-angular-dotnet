using Recipe_website.Core.Repositories_Interface;
using Recipe_website.Core.Services_Interface;
using Recipe_website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_website.Service.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository _repository;
    
        public RecipeService(IRecipeRepository repository)
        {
            _repository = repository;
        }

        //שליפת כל המתכונים
        public List<Recipe> Get()
        {
            return _repository.Get();
        }

        //שליפת מתכון לפי קוד מתכון
        public Recipe GetRecipe(int RecipeId)
        {
            return _repository.GetRecipe(RecipeId);
        }       

        //הוספת מתכון
        public Recipe AddRecipe(Recipe recipe)
        {
            return _repository.AddRecipe(recipe);
        }
    }
}
