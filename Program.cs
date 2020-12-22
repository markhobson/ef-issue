using System;

namespace ef_issue
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            int id;
            
            // Create a new blog with a post titled "A"
            using (var db = new BloggingContext())
            {
                var blog = new Blog
                {
                    Post = new Post { Title = "A" }
                };
                db.Add(blog);
                db.SaveChanges();
                id = blog.Id;
            }
            
            // Update blog post title to "B" and add image
            using (var db = new BloggingContext())
            {
                var blog = db.Blogs.Find(id);
                // Uncomment this to work around the problem
                // var _ = blog.Post;
                blog.Post = new Post { Title = "B" };
                blog.Post.Images.Add(new Image { Url = "http://example.com/" });
                db.SaveChanges();
            }
            
            // Fetch blog post title -- should be "B" but is "A"
            using (var db = new BloggingContext())
            {
                var blog = db.Blogs.Find(id);
                Console.WriteLine($"Blog post title = {blog.Post.Title}");
            }
        }
    }
}
