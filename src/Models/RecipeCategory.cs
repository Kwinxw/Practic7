using System;
using System.Collections.Generic;

namespace Practic5.Models;

public partial class RecipeCategory
{
    public int RecipeCategoryId { get; set; }

    public int? RecipeId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
