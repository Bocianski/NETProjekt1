namespace Forum.Models
{
    public class ForumUser
    {
        public int Id { get; set; }
        public required string? Name { get; set; }
        public required string? Email { get; set; }
    }
}
