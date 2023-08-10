using Blog_Api.Data;
using Blog_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Api.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController : Controller
    {
        private readonly BlogApiDbContext dbContext;

        public PostController(BlogApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IEnumerable<Post> GetAllPosts()
        {
            return dbContext.posts.ToList();
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
        {
            var post = await dbContext.posts.FindAsync(id);

            if(post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(Post post)
        {
            await dbContext.posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

            return Ok(post);
        }

        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePost( int id, UpdatePostRequest updatePostRequest) 
        {
            var post = await dbContext.posts.FindAsync(id);
            if (post != null) 
            {
                post.Title = updatePostRequest.Title;
                post.Content = updatePostRequest.Content;

                await dbContext.SaveChangesAsync();
                return Ok(post);
            }
            return NotFound();

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            var post = await dbContext.posts.FindAsync(id);
            if(post != null)
            {
                dbContext.posts.Remove(post);
                dbContext.SaveChanges();
                return Ok(post);
            }
            return NotFound();
        }
    }
}
