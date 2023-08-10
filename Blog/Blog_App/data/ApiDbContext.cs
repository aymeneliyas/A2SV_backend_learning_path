using System;
using Microsoft.EntityFrameworkCore;
using Blog_App.models;

namespace Blog_App.data;

public class ApiDbContext : DbContext
{
    public virtual DbSet<Post> Posts{get; set;}
    public virtual DbSet<Comment> Comments{get; set;}
 
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Database=blog;Username=postgres;Password=aymila777");
    }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity =>
        {
            entity
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Post_Comment");
        });
    }
}