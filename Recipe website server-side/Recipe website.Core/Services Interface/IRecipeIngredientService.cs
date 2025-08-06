using Recipe_website.Core.DTOs;
using Recipe_website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_website.Core.Services_Interface
{
    public interface IRecipeIngredientService
    {
        //שליפת רשימת רכיבים לפי קוד מתכון
        public List<RecipeIngredient> GetRecipeIngredient(int RecipeId);

        //הוספת רכיבים למתכון
        public Recipe AddIngredients(int RecipeId, AddRecipeIngredientsRequestDTO requestData);
    }
}
