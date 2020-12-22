# ef-issue

This program creates the following EF model:

    Blog 1<--->1 Post 1<--->m Images

Then performs the following operations:

1. Create a new blog with a post titled "A"
1. Update blog post title to "B" and add image
1. Fetch blog post title

The fetched blog title should be "B" but is "A".

## To reproduce

1. Create the database:

       dotnet tool install --global dotnet-ef
       dotnet ef migrations add InitialCreate
       dotnet ef database update

1. Run the app:

       dotnet run

    And it incorrectly outputs:

        Blog post title = A

1. Uncomment the line:

        // var _ = blog.Post;

1. Re-run the app and it correctly outputs:

        Blog post title = B
