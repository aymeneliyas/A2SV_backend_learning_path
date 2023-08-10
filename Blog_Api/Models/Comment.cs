namespace Blog_Api.Models
{
    public class Comment
    {
        public int Id{ get; set; }
        public string Text { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
