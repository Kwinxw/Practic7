using System;
using System.Collections.Generic;

namespace BlazorApp1.Models;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public int? UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public int? DeletedByUserId { get; set; }

    public virtual User? DeletedByUser { get; set; }

    public virtual ICollection<Photo> Photos { get; } = new List<Photo>();

    public virtual ICollection<RecipeCategory> RecipeCategories { get; } = new List<RecipeCategory>();

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual User? User { get; set; }
}
