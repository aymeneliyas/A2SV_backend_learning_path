using Blog_App.data;
using Blog_App.models;
using Microsoft.EntityFrameworkCore;

namespace Blog_App.Manager;
public class PostManager
{
    private readonly ApiDbContext ctx;
    public PostManager()
    {
        
    }
    public PostManager(ApiDbContext context)
    {
        ctx = context;
    }

    public List<Post> GetAllPosts()
    {
    
        return ctx.Posts.ToList();
    }

    public Post GetPostById(int postId)
    {
        return ctx.Posts.Find(postId);
    }

    public Post Create(Post post)
    {
        if (string.IsNullOrWhiteSpace(post.Title))
            throw new InvalidOperationException("post must have title");
        if (string.IsNullOrWhiteSpace(post.Content))
            throw new InvalidOperationException("post must have content");

        
        ctx.Posts.Add(post);
        ctx.SaveChanges();
        
        
        return post;
    }

    public Post Update(int id, string? title=null, string? content=null)
    {
        Post? post = ctx.Posts.Find(id);

        if (post is null)
        {
            throw new InvalidOperationException("no posts found");
        }

        post.Title = title ?? post.Title;
        post.Content = content ?? post.Content;
        ctx.SaveChanges();

        return post;
    }

    public void Delete(int id)
    {
        Post? post = ctx.Posts.Find(id);
        if (post is null)
            throw new InvalidOperationException("no posts found by that id");
        
        ctx.Posts.Remove(post);
        ctx.SaveChanges();
    }
}