using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Forum.Models;

namespace Forum.Data
{
    public class ForumContext : IdentityDbContext
    {
        public ForumContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<ForumUser>(); 
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ForumUser> ForumUser {  get; set; }
    }
}
