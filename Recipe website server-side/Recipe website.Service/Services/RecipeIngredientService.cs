using Recipe_website.Core.DTOs;
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
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private IRecipeIngredientRepository _recipeIngredientRepository;
        public RecipeIngredientService(IRecipeIngredientRepository recipeIngredientRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
        }

        //הוספת רכיבים למתכון
        public Recipe AddIngredients(int RecipeId, AddRecipeIngredientsRequestDTO requestData)
        {
            return _recipeIngredientRepository.AddIngredients(RecipeId, requestData);
        }

        //שליפת רשימת רכיבים לפי קוד מתכון
        public List<RecipeIngredient> GetRecipeIngredient(int RecipeId)
        {
            return _recipeIngredientRepository.GetRecipeIngredient(RecipeId);
        }
    }
}
