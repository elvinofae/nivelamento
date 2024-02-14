using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Context
{

    public class BlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            optionsBuilder.UseSqlite(@$"Data Source={currentDirectory}\Blog.db;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
