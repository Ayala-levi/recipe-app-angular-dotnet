using Recipe_website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_website.Core.Services_Interface
{
    public interface IRecipeService
    {        
        //שליפת כל המתכונים
        public List<Recipe> Get();

        //שליפת מתכון לפי קוד מתכון
        public Recipe GetRecipe(int RecipeId);

        //הוספת מתכון
        public Recipe AddRecipe(Recipe recipe);
    }
}
