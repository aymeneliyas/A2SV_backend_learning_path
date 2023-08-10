using Blog_App.data;
using Blog_App.models;
using Blog_App.Manager;

namespace Blog_App_test;

public class CommentManagerTest{
    private CommentManager commentManager;
    private ApiDbContext context = new ApiDbContext();
    public CommentManagerTest(ApiDbContext context)
    {
        commentManager = new CommentManager(context);
    }
        
    [Fact]
    public void Create_ReturnsComment()
    {
        context = new ApiDbContext();
        CommentManagerTest CommentManagerTest= new CommentManagerTest(context);
        // Arrange
        var newComment = new Comment { Text = "test"};
        var p = commentManager.Create(newPost);

        //Assert

        Assert.Equal("Test", p.Text);
        Assert.NotNull(p);

    }

    [Fact]
    public void GetPostById_ReturnsComment()
    {
         // Arrange
        var commentManager = new CommentManager();
        var newComment = new Post { Text = "Test"};
        var neww = commentManager.Create(newPost);

        // Act
        var result = commentManager.GetPostById(newPost.PostId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test", result.Text);
    
        
    }

    [Fact]
    public void Update_IfIdFound_UpdatesComment()
    {
        // Arrange
        var commentManager = new CommentManager();
        var newComment = new Comment { Text = "Test" };
        var neww = commentManager.Create(newComment);

        // Act
        var text = "new Test updated";
        commentManager.Update(neww.CommentId, text);

        // Assert
        var updatedPost = commentManager.GetPostById(newComment.CommentId);
        Assert.NotNull(updatedComment);
        Assert.Equal("new Test updated", updatedPost.Text);
    }

    [Fact]
    public void Update_IfIdNotFound_ReturnsNoCommentFound()
    {
        // Arrange
        var commentManager = new CommentManager();
        var newComment = new Post { Text = "Test"};
        // var neww = CommentManager.Create(newPost);

        // Act
        var Title = "new Test updated";
        commentManager.Update(1,Text);

        // Assert
        var updatedComment = CommentManager.GetPostById(newPost.PostId);
        Assert.Null(updatedComment);
    }

    [Fact]
    public void Delete_ifIdFound_DeletesPost()
    {
        // Arrange
        var commentManager = new CommentManager();
        var newcomment = new Post { Title = "Test"};
        commentManager.Create(newcomment);

        // Act
        commentManager.Delete(newcomment.PostId);

        // Assert
        var deletedComment = commentManager.GetPostById(newcomment.CommentId);
        Assert.Null(deletedComment);
    }

    [Fact]
     public void Delete_ifIdNotFound_DeletesPost()
    {
        // Arrange
        var CommentManager = new CommentManager();
        var newComment = new Post { Title = "Test", Content = "Content" };
        // CommentManager.Create(newPost);

        // Act
        CommentManager.Delete(1);

        // Assert
        var deletedComment = commentManager.GetPostById(newComment.CommentId);
        Assert.Null(deletedComment);
    }

}