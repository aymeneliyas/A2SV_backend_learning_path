using Blog_App.data;
using Blog_App.models;
using Blog_App.Manager;

namespace Blog_App_test;

public class PostManagerTest
{
    private PostManager postManager;
    private CommentManager commentManager;
    private ApiDbContext context = new ApiDbContext();
    public PostManagerTest(ApiDbContext context)
    {
        postManager = new PostManager(context);
        commentManager = new CommentManager(context);
    }
        
    [Fact]
    public void Create_ReturnsPost()
    {
        context = new ApiDbContext();
        PostManagerTest postManagerTest= new PostManagerTest(context);
        // Arrange
        var newPost = new Post { Title = "test", Content = "nothing" };
        var p = postManager.Create(newPost);

        //Assert

        Assert.Equal("Test", p.Title);
        Assert.NotNull(p);

    }

    [Fact]
    public void GetPostById_ReturnsPost()
    {
         // Arrange
        var postManager = new PostManager();
        var newPost = new Post { Title = "Test", Content = "nothing" };
        var neww = postManager.Create(newPost);

        // Act
        var result = postManager.GetPostById(newPost.PostId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Post", result.Title);
        Assert.Equal("nothing",result.Content);
        
    }

    [Fact]
    public void Update_IfIdFound_UpdatesPost()
    {
        // Arrange
        var postManager = new PostManager();
        var newPost = new Post { Title = "Test", Content = "nothing" };
        var neww = postManager.Create(newPost);

        // Act
        var Title = "new Test updated";
        var Content = "new content updated";
        postManager.Update(neww.PostId, Title,Content);

        // Assert
        var updatedPost = postManager.GetPostById(newPost.PostId);
        Assert.NotNull(updatedPost);
        Assert.Equal("new Test updated", updatedPost.Title);
        Assert.Equal("new content updated", updatedPost.Content);
    }

    [Fact]
    public void Update_IfIdNotFound_ReturnsNoPostsFound()
    {
        // Arrange
        var postManager = new PostManager();
        var newPost = new Post { Title = "Test", Content = "nothing" };
        // var neww = postManager.Create(newPost);

        // Act
        var Title = "new Test updated";
        var Content = "new content updated";
        postManager.Update(1,Title,Content);

        // Assert
        var updatedPost = postManager.GetPostById(newPost.PostId);
        Assert.Null(updatedPost);
    }

    [Fact]
    public void Delete_ifIdFound_DeletesPost()
    {
        // Arrange
        var postManager = new PostManager();
        var newPost = new Post { Title = "Test Post", Content = "Content" };
        postManager.Create(newPost);

        // Act
        postManager.Delete(newPost.PostId);

        // Assert
        var deletedPost = postManager.GetPostById(newPost.PostId);
        Assert.Null(deletedPost);
    }

    [Fact]
     public void Delete_ifIdNotFound_DeletesPost()
    {
        // Arrange
        var postManager = new PostManager();
        var newPost = new Post { Title = "Test Post", Content = "Content" };
        // postManager.Create(newPost);

        // Act
        postManager.Delete(1);

        // Assert
        var deletedPost = postManager.GetPostById(newPost.PostId);
        Assert.Null(deletedPost);
    }

}