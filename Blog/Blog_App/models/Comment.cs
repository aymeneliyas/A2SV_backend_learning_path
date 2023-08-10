using Blog_App.models;
namespace Blog_App.models;

public class Comment : BaseEntity
{
    public int CommentId{get; set;}
    public int PostId{get; set;}
    public string Text{get; set;}
    public DateTime CreatedAt{get; set;}

    public Post? Post { get; set; }
}