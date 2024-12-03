using System;
using System.Collections.Generic;

namespace BlazorApp1.Models;

public partial class Photo
{
    public int PhotoId { get; set; }

    public int? RecipeId { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
