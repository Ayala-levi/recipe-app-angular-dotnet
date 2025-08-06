using System;
using System.Collections.Generic;

namespace Recipe_website.Data.Entities;

public partial class Ingredient
{
    //קוד רכיב
    public int IngredientId { get; set; }
    //שם רכיב
    public string IngredientName { get; set; } = null!;

    //RecipeIngredient-טבלת רבים לרבים
    //לכל רכיב יש הרבה מתכונים ולכן וש פה רשימה מסוג רכיב למתכון וזה virtual
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; } = new List<RecipeIngredient>();
}
