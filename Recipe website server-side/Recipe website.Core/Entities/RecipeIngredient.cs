using System;
using System.Collections.Generic;

namespace Recipe_website.Data.Entities;

public partial class RecipeIngredient
{
    public int RecipeIngredientId { get; set; }
    //קוד מתכון
    public int RecipeId { get; set; }
    //קוד רכיב
    public int IngredientId { get; set; }
    //כמות
    public string? Quantity { get; set; }
    //קישור לרכיב
    public virtual Ingredient Ingredient { get; set; } = null!;
    //קישור למתכון
    public virtual Recipe Recipe { get; set; } = null!;
}
