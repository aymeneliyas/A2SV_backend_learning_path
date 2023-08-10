using Blog_App.models;
namespace Blog_App.models;

public class Post : BaseEntity
{    
    public int PostId{get; set;}
    public string Title{get; set;}
    public string Content{get; set;}
    public DateTime CreatedAt{get; set;}
    public List<Comment>? Comments { get; set; }
}