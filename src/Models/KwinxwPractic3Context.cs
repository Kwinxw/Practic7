using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practic5.Models;

public partial class KwinxwPractic3Context : DbContext
{
    public KwinxwPractic3Context()
    {
    }

    public KwinxwPractic3Context(DbContextOptions<KwinxwPractic3Context> options)
        : base(options)
    {
    }

    public async Task<User?> Login(string email, string password)
    {
        return await Users.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeCategory> RecipeCategories { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=kwinxw_Practic3;User Id=kwinxw_Practic3;Password=Vadim2006;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2BDEC34605");

            entity.HasIndex(e => e.Name, "UQ__Categori__737584F61C7ECD95").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.PhotoId).HasName("PK__Photos__21B7B5827E7B50EB");

            entity.Property(e => e.PhotoId).HasColumnName("PhotoID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhotoUrl).HasMaxLength(255);
            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Photos)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__Photos__RecipeID__3493CFA7");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipes__FDD988D069318F87");

            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedByUserId).HasColumnName("DeletedByUserID");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.DeletedByUser).WithMany(p => p.RecipeDeletedByUsers)
                .HasForeignKey(d => d.DeletedByUserId)
                .HasConstraintName("FK__Recipes__Deleted__31B762FC");

            entity.HasOne(d => d.User).WithMany(p => p.RecipeUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Recipes__UserID__2DE6D218");
        });

        modelBuilder.Entity<RecipeCategory>(entity =>
        {
            entity.HasKey(e => e.RecipeCategoryId).HasName("PK__RecipeCa__747A033BED0F9081");

            entity.Property(e => e.RecipeCategoryId).HasColumnName("RecipeCategoryID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

            entity.HasOne(d => d.Category).WithMany(p => p.RecipeCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__RecipeCat__Categ__40F9A68C");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeCategories)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__RecipeCat__Recip__40058253");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE14526E91");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("FK__Reviews__RecipeI__3864608B");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserID__395884C4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC1ED4FAC9");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E42AAB75D5").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053457565CA7").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
