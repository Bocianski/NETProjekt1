namespace Forum.Models
{
    public class ForumThread
    {
        public int Id { get; set; }
        public required string? Title { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
