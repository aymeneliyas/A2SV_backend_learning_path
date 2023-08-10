using Blog_Api.Data;
using Blog_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Api.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : Controller
    {
        private readonly BlogApiDbContext dbContext;

        public CommentController(BlogApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IEnumerable<Comment> GetAllComments()
        {
            return dbContext.comments.ToList();
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetComment([FromRoute] int id)
        {
            var comment = await dbContext.comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            var com = dbContext.posts.Find(comment.PostId);
            if (com == null)
            {
                return NotFound();
            }
            await dbContext.comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();

            return Ok(comment);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateComment(int id, UpdateCommentRequest updateCommentRequest)
        {
            var comment = await dbContext.comments.FindAsync(id);
            if (comment != null)
            {
                comment.Text = updateCommentRequest.Text;
            

                await dbContext.SaveChangesAsync();
                return Ok(comment);
            }
            return NotFound();

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var comment = await dbContext.comments.FindAsync(id);
            if (comment == null)
            {
                dbContext.comments.Remove(comment);
                dbContext.SaveChanges();
                return Ok(comment);
            }
            return NotFound();
        }
    }
}
