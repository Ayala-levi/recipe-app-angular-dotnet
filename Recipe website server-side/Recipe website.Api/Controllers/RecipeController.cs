using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Recipe_website.Core.Services_Interface;
using Recipe_website.Data.Entities;
using Recipe_website.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe_website.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //בקשות למתכונים
    public class RecipeController : ControllerBase
    {
        private IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        //שליפת כל המתכונים
        [HttpGet]
        public List<Recipe> Get()
        {
            try
            {
                return _recipeService.Get();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //שליפת מתכון לפי קוד מתכון
        [HttpGet("GetRecipe/{RecipeId}")]
        public Recipe GetRecipe(int RecipeId)
        {
            try
            {
                var recipe = _recipeService.GetRecipe(RecipeId);

                if (recipe == null)
                {
                    return null;
                }

                return recipe;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing your request.");
                return null;
            }
        }

        //הוספת מתכון
        [HttpPost]
        public ActionResult<Recipe> AddRecipe([FromBody] Recipe recipe)
        {
            try
            {
                return _recipeService.AddRecipe(recipe);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        //להוספת תמונה 
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage()
        {
            // מנסה לקבל את הקובץ הראשון שנשלח בטופס (Request.Form.Files)
            var file = Request.Form.Files.FirstOrDefault();

            // בודק אם קיים קובץ והאם אורכו גדול מ-0 (כלומר, קובץ נשלח)
            if (file != null && file.Length > 0)
            {
                // קובע את הנתיב לתיקיית ההעלאות.
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                // בודק אם תיקיית ההעלאות קיימת, ואם לא - יוצר אותה.
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                // יוצר שם קובץ ייחודי באמצעות GUID (מזהה ייחודי גלובלי)
                // ומוסיף את סיומת הקובץ המקורית (למשל, ".jpg", ".png").
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                // יוצר את הנתיב המלא לקובץ שישמר על השרת.
                var filePath = Path.Combine(uploadsFolderPath, fileName);

                // פותח זרם (Stream) לכתיבת הקובץ החדש.
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    // מעתיק באופן אסינכרוני את תוכן הקובץ שהתקבל מהבקשה אל הזרם של הקובץ החדש.
                    await file.CopyToAsync(stream);
                }

                // החזר את הנתיב היחסי של התמונה
                return Ok(new { path = "/images/" + fileName });
            }

            return BadRequest("לא נשלחה תמונה.");
        }
    }
}


