using Microsoft.EntityFrameworkCore;
using Recipe_website.Core.DTOs;
using Recipe_website.Core.Repositories_Interface;
using Recipe_website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_website.Data.Repositories
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private DataContext _context;
        public RecipeIngredientRepository(DataContext context)
        {
            _context = context;
        }
        //שליפת רשימת רכיבים לפי קוד מתכון
        public List<RecipeIngredient> GetRecipeIngredient(int RecipeId)
        {
            return _context.RecipeIngredients.Include(y=>y.Ingredient)
                .Where(x=>x.RecipeId == RecipeId).ToList();
        }

        //הוספת רכיבים למתכון
        public Recipe AddIngredients(int RecipeId, AddRecipeIngredientsRequestDTO requestData)
        {
            // בדוק אם המתכון קיים
            var recipe = _context.Recipes.FirstOrDefault(r => r.RecipeId == RecipeId);
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found");
                return null;
            }

            //בדיקת הרשימות
            if (requestData == null || requestData.IngredientIds == null || !requestData.IngredientIds.Any() 
                || requestData.Quantities == null || !requestData.Quantities.Any())
            {
                Console.WriteLine("Ingredient IDs and quantities must be provided.");
                return null;
            }

            //בדיקה שהרשימות זהות
            if (requestData.IngredientIds.Count != requestData.Quantities.Count)
            {
                Console.WriteLine("The number of ingredient IDs must match the number of quantities.");
                return null;
            }

            //  יצירת רשימת רכיבי מתכון (RecipeIngredient)
            var recipeIngredientsToAdd = new List<RecipeIngredient>();
            for (int i = 0; i < requestData.Quantities.Count(); i++)
            {
                recipeIngredientsToAdd.Add(new RecipeIngredient
                {
                    RecipeId = RecipeId,
                    IngredientId = requestData.IngredientIds[i],
                    Quantity = requestData.Quantities[i]
                });
            }

            // הוספה ושמירה למסד הנתונים
            _context.RecipeIngredients.AddRange(recipeIngredientsToAdd);
            _context.SaveChanges();

            // טען מחדש את המתכון עם הרכיבים שלו כדי להחזיר את המצב המעודכן
            return _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient) //טעינה להוטה של קשרים נוספים ברמה עמוקה יותר
                .FirstOrDefault(r => r.RecipeId == RecipeId);
        }

    }
}



//        var updatedRecipe = _recipeService.AddIngredientsToRecipe(
//            recipeId,
//            requestData.IngredientIds,
//            requestData.Quantities
//        );

//        if (updatedRecipe == null)
//        {
//            // אם הסרוויס החזיר null (לדוגמה, כי המתכון לא נמצא)
//            return NotFound($"Recipe with ID {recipeId} not found.");
//        }

//        return Ok(updatedRecipe); // החזר את המתכון המעודכן
//    }




//מה שהיה בהתחלה

//יצירת רשימת רכיבים למתכון כאשר כל אחד מקושר לקוד מתכון שהתקבל
// והקוד רכיב זה כל אחד מהרשימה שהתקבלה
//var ingredientsToAdd = IngredientIds.Select(ingredientId => new RecipeIngredient
//{
//    RecipeId = RecipeId,
//    IngredientId = ingredientId
//}).ToList();

//_context.RecipeIngredients.AddRange(ingredientsToAdd);
//_context.SaveChanges();

//// טען מחדש את המתכון עם הרכיבים שלו כדי להחזיר את המצב המעודכן
//return _context.Recipes
//    .Include(r => r.RecipeIngredients)
//    .ThenInclude(ri => ri.Ingredient) //טעינה להוטה של קשרים נוספים ברמה עמוקה יותר
//    .FirstOrDefault(r => r.RecipeId == RecipeId);
//        }