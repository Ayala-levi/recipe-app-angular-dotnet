using System;
using System.Collections.Generic;

namespace Recipe_website.Data.Entities;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    //רמה-קל בינוני קשה
    public string? DifficultyLevel { get; set; }

    //משך זמן
    public int? PreparationTime { get; set; }
    //מספר מנות
    public int? Servings { get; set; }
    //הוראות
    public string? Instructions { get; set; }
    //קוד משתמש
    public int? UserId { get; set; }

    //RecipeIngredient-טבלת רבים לרבים
    //לכל מתכון יש הרבה רכיבים ולכן וש פה רשימה מסוג רכיב למתכון וזה virtual
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; } = new List<RecipeIngredient>();

    public virtual User? User { get; set; }
}
