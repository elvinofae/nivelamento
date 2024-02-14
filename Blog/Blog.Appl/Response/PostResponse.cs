namespace Blog.Appl.Response
{
    public class PostResponse
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
