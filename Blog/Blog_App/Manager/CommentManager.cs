using Blog_App.data;
using Blog_App.models;
using Microsoft.EntityFrameworkCore;

namespace Blog_App.Manager;

public class CommentManager
{
    private readonly ApiDbContext ctx;
    public CommentManager()
    {

    }
    public CommentManager(ApiDbContext context)
    {
        ctx = context;
    }

    public List<Comment> GetAllComments()
    {
        // using var ctx = new ApiDbContext();
        return ctx.Comments.ToList();
    }
    public Comment? GetCommentByPost(int postId, int commentId)
    {
        return ctx.Comments.SingleOrDefault(c => c.PostId == postId && c.CommentId == commentId);
    }

    public Comment? GetCommentById(int commentId)
    {
       return ctx.Comments.Find(commentId);
    }

    public Comment Create(Comment comment)
    {
        if (string.IsNullOrWhiteSpace(comment.Text))
            throw new InvalidOperationException("comment must have text");

        ctx.Comments.Add(comment);
        ctx.SaveChanges();

        return comment;
    }

    public Comment Update(int id, string text)
    {
        Comment? comment = ctx.Comments.Find(id);

        if (comment is null)
        {
            throw new InvalidOperationException("Comment not found");
        }

        comment.Text = text ?? comment.Text;
        ctx.SaveChanges();

        return comment;
    }

    public void Delete(int id)
    {
        Comment? comment = ctx.Comments.Find(id);
        if (comment is null)
            throw new InvalidOperationException("comment not found by id");

        ctx.Comments.Remove(comment);
        ctx.SaveChanges();
    }

}