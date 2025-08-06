using Microsoft.AspNetCore.Mvc;
using Recipe_website.Core.DTOs;
using Recipe_website.Core.Services_Interface;
using Recipe_website.Data.Entities;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe_website.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //בקשות רכיבים למתכון
    public class RecipeIngredientController : ControllerBase
    {
       private IRecipeIngredientService _recipeIngredientService;
        public RecipeIngredientController(IRecipeIngredientService recipeIngredientService) 
        { 
            _recipeIngredientService = recipeIngredientService;
        }

        //שליפת רשימת רכיבים לפי קוד מתכון
        [HttpGet("{RecipeId}")]
        public List<RecipeIngredient> GetRecipeIngredient(int RecipeId)
        {
            try
            {
                return _recipeIngredientService.GetRecipeIngredient(RecipeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        //הוספת רכיבים למתכון
        [HttpPost("{RecipeId}")]
        public Recipe AddIngredients(int RecipeId,[FromBody] AddRecipeIngredientsRequestDTO requestData)
        {
            try
            {
                return _recipeIngredientService.AddIngredients(RecipeId, requestData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}
