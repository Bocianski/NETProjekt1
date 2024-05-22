using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data
{
    public class ForumContext : IdentityDbContext 
    {
        public ForumContext() { }
    }
}
