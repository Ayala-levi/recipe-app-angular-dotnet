using Recipe_website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_website.Core.Repositories_Interface
{
    public interface IIngredientRepository
    {
        //שליפת רכיבים
        public List<Ingredient> Get();

        //הוספת רכיב
        public Ingredient AddIngredient(Ingredient ingredient);
    }
}
