using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_website.Core.DTOs
{
    public class AddRecipeIngredientsRequestDTO
    {
        //יצרנו את זה כי לא יכלנו לשלוח בהוספת רכיבים 2 רשימות בגוף הבקשה
        //לכן נשלח אובייקט שמכיל 2 רשימות
        public List<int> IngredientIds { get; set; }
        public List<string> Quantities { get; set; }
    }
}
