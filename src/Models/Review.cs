using System;
using System.Collections.Generic;

namespace BlazorApp1.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? RecipeId { get; set; }

    public int? UserId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual User? User { get; set; }
}
