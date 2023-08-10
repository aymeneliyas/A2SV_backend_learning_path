using Blog_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_Api.Data
{
    public class BlogApiDbContext : DbContext
    {
        public BlogApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> posts { get; set; }
        public DbSet<Comment> comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(p => p.Post)
                .WithMany(c => c.comments)
                .HasForeignKey(id => id.PostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Comment_Post");
            });


        }
    }
}
