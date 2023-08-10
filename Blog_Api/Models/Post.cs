using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Api.Models
{
    public class Post
    {
        
        public int Id {  get; set; }   
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Comment> comments { get; set; }
    }
}
