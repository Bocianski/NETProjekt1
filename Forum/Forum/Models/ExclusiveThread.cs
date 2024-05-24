namespace Forum.Models
{
    public class ExclusiveThread : ForumThread
    {
        public ICollection<ForumUser> Users { get; set; } = new List<ForumUser>();
    }
}
