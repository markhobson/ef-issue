# ef-issue

This program creates the following EF model:

     Blog
      |   1..1
     Post
     /|\  1..m
    Image

Then performs the following operations:

1. Create a new Blog with a Post titled "A"
1. Fetch the Blog, replace its Post with a new entity titled "B", and then add an Image to the Post
1. Fetch the Post and display its title

The fetched Post title should be "B" but is "A".

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

## See also

* [#23757 Lazy one-to-one entity changes lost on one-to-many fetch](https://github.com/dotnet/efcore/issues/23757)
