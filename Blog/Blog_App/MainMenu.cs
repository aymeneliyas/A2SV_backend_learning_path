using Blog_App.Manager;
using Blog_App.data;
using Blog_App.models;
namespace Blog_App;
public class MainMenu
{
    private PostManager postManager;
    private CommentManager commentManager;
    public ApiDbContext context = new ApiDbContext();
    public MainMenu(ApiDbContext context)
    {
        postManager = new PostManager(context);
        commentManager = new CommentManager(context);
    }
        

    public void Start()
    {
        while (true)
        {
            Console.Clear();
    
            Console.WriteLine("1. Create Post");
            Console.WriteLine("2. Display All Post");
            Console.WriteLine("3. Display Post");
            Console.WriteLine("4. update Post");
            Console.WriteLine("5. Delete Post");
            Console.WriteLine("6. Create Comment");
            Console.WriteLine("7. Display Comment");
            Console.WriteLine("8. Delete Comment");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");
            var x = Console.ReadLine();

            switch (x)
            {
                case "1":
                    CreatePost();
                    break;

                case "2":
                    DisplayAllPost();
                    break;

                case "3":
                    DisplayPost();
                    break;

                case "4":
                    EditPost();
                    break;

                case "5":
                    DeletePost();
                    break;

                case "6":
                    CreateComment();
                    break;
                
                case "7":
                    DisplayAllComment();
                    break;

                case "8":
                    DeleteComment();
                    break;

                case "9":
                    return;

                default:
                    Console.Write("Press Enter to continue");
                    break;
            }
        }



    }
    public void CreatePost()
    {   
        Console.WriteLine("enter post title");
        var title = Console.ReadLine();

        while (title == null)
        {
            Console.WriteLine("Post title cannot be empty.enter again");
            title = Console.ReadLine()!;
        }

        Console.WriteLine("enter post content");
        var content = Console.ReadLine();
        while (content == null)
        {
            Console.WriteLine("Post comment cannot be empty.enter again");
            content = Console.ReadLine()!;
        }
     
        var newPost = new Post { Title = title, Content = content };
        var p = postManager.Create(newPost);
        Console.WriteLine(p);
    }

    public void EditPost()
    {
        Console.WriteLine("enter post id to edit");
        var id = Convert.ToInt32(Console.ReadLine());
        if(id >0)
        {
            var editedPost = postManager.GetPostById(id);
            if (editedPost != null)
            {
                Console.WriteLine("Enter new post title");
                var newTitle = Console.ReadLine()!;

                while (string.IsNullOrWhiteSpace(newTitle))
                {
                    Console.WriteLine("Post title cannot be empty.enter again");
                    newTitle = Console.ReadLine()!;
                }

                Console.WriteLine("Enter new post content: ");
                var newContent = Console.ReadLine()!;

                while (string.IsNullOrWhiteSpace(newContent))
                {
                    Console.WriteLine("Post content cannot be empty.enter again");
                    newContent = Console.ReadLine()!;
                }
                editedPost.Title = newTitle;
                editedPost.Content = newContent;
        
                postManager.Update(editedPost.Id,newTitle,newContent);
                Console.WriteLine("Post updated successfully.");
            }
            else{
                Console.WriteLine("post not found");
            }
        }

    }

    public void DeletePost()
    {
        Console.WriteLine("enter post id to delete");
        var id = Convert.ToInt32(Console.ReadLine());
        if(id>0)
        {
            var deletedPost = postManager.GetPostById(id);
            if (deletedPost != null)
            {
                postManager.Delete(id);
                Console.WriteLine("Post deleted successfully.");
            }
            else
                Console.WriteLine("Post id not found.");   
            Console.ReadLine();
        }
    }

    public void DisplayPost()
    {
        Console.WriteLine("enter post id ");
        int id = Convert.ToInt32(Console.ReadLine());
        var post = postManager.GetPostById(id);
        Console.WriteLine("{0,-10}{1,-10}{2,10}{3}","Id","Title","Content","Created_At");
        Console.WriteLine("{0,-10}{1,-10}{2,-10}{3}",post.Id,post.Title,post.Content,post.CreatedAt);
        Console.ReadLine();
    }

    public void DisplayAllPost()
    {
        Console.WriteLine("Current Posts:");
        Console.WriteLine("{0,-10}{1,-10}{2,10}{3}","Id","Title","Content","Created_At");
        foreach (var post in postManager.GetAllPosts())
        {
    
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3}",post.Id,post.Title,post.Content,post.CreatedAt);
            
        }
        Console.ReadLine();
    }

    public void CreateComment()
    {   
        Console.WriteLine("enter post id");
        var id = Convert.ToInt32(Console.ReadLine());

        var postid = postManager.GetPostById(id);
        if (postid != null)
        {
            Console.WriteLine("enter comment to be posted");
            var text = Console.ReadLine();
            
            while (text == null)
            {
                Console.WriteLine("Post title cannot be empty.enter again");
                text = Console.ReadLine()!;
            }
            var newComment = new Comment { Text = text, PostId = postid.Id};
            var p = commentManager.Create(newComment);
            Console.WriteLine("p");
        }
        else
        {
            Console.WriteLine("post not found");
        }

        
     
    }


    public void DisplayComment()
    {
        Console.WriteLine("enter comment id ");
        int id = Convert.ToInt32(Console.ReadLine());
        var comment = commentManager.GetCommentById(id);
        Console.WriteLine("{0,-10}{1,-10}{2,-10}{3}","Id","post id ","comment","Created_At");
        Console.WriteLine("{0,-10}{1,-10}{2,-10}{3}",comment.Id,comment.PostId,comment.Text,comment.CreatedAt);
        Console.ReadLine();
    }

    public void DisplayAllComment()
    {
        Console.WriteLine("Current Posts:");
        Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}","Id","Title","Content","Created_At");
        foreach (var comment in commentManager.GetAllComments())
        {
    
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}",comment.Id,comment.PostId,comment.Text,comment.CreatedAt);
            
        }
        Console.ReadLine();
    }

    public void DeleteComment()
    {
        Console.WriteLine("enter comment id to delete");
        var id = Convert.ToInt32(Console.ReadLine());
        if(id>0)
        {
            var deletedComment = commentManager.GetCommentById(id);
            if (deletedComment != null)
            {
                commentManager.Delete(id);
                Console.WriteLine("comment deleted successfully.");
            }
            else
                Console.WriteLine("comment id not found.");   
            Console.ReadLine();
        }

    }

}
