using Recipe_website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_website.Core.Services_Interface
{
    public interface IIngredientService
    {
        //שליפת רכיבים
        public List<Ingredient> Get();

        //הוספת רכיב
        public Ingredient AddIngredient(Ingredient ingredient);
    }
}
