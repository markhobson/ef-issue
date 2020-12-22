using System;
using Microsoft.EntityFrameworkCore;

namespace ef_issue
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Image> Images { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=blogging.db")
                .UseLazyLoadingProxies()
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasOne(blog => blog.Post)
                .WithOne(post => post.Blog)
                .HasForeignKey<Post>(post => post.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Image>()
                .HasOne(image => image.Post)
                .WithMany(post => post.Images)
                .HasForeignKey(image => image.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
