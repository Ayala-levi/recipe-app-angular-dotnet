using System;
using System.Collections.Generic;

namespace Recipe_website.Data.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FirstName { get; set; }
    
    //לכל משתמש יש הרבה מתכונים ולכן וש פה רשימה מסוג מתכון וזה virtual
    public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();
}
