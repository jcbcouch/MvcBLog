using Microsoft.EntityFrameworkCore;
using mvcBlog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace mvcBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Configure the one-to-many relationship
            builder.Entity<Post>()
                .HasOne(p => p.User)                // A post has one user
                .WithMany(u => u.Posts)              // A user can have many posts
                .HasForeignKey(p => p.UserId)        // Foreign key in Post table
                .OnDelete(DeleteBehavior.Cascade);   // Delete posts when user is deleted
        }
    }
}
