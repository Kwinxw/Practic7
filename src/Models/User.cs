using System;
using System.Collections.Generic;

namespace Practic5.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Recipe> RecipeDeletedByUsers { get; set; } = new List<Recipe>();

    public virtual ICollection<Recipe> RecipeUsers { get; set; } = new List<Recipe>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
