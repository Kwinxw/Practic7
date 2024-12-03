using System;
using System.Collections.Generic;

namespace BlazorApp1.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RecipeCategory> RecipeCategories { get; } = new List<RecipeCategory>();
}
