using Microsoft.AspNetCore.Mvc;
using Recipe_website.Core.Services_Interface;
using Recipe_website.Data.Entities;
using Recipe_website.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe_website.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //בקשות לרכיבים
    public class IngredientController : ControllerBase
    {
        private IIngredientService _ingredientService;
        public IngredientController(IIngredientService ingredientService) { 
            _ingredientService = ingredientService;
        }
        
        //שליפת רכיבים
        [HttpGet]
        public List<Ingredient> Get()
        {
            try
            {
                return _ingredientService.Get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //הוספת רכיב
        [HttpPost]
        public Ingredient AddIngredient([FromBody] Ingredient ingredient)
        {
            try
            {
                return _ingredientService.AddIngredient(ingredient);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
