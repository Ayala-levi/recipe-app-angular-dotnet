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
    public class IngredientService : IIngredientService
    {
        private IIngredientRepository _ingredientRepository;
        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        //שליפת רכיבים
        public List<Ingredient> Get()
        {
            return _ingredientRepository.Get();
        }
        //הוספת רכיב
        public Ingredient AddIngredient(Ingredient ingredient)
        {
            return _ingredientRepository.AddIngredient(ingredient);
        }
    }
}
