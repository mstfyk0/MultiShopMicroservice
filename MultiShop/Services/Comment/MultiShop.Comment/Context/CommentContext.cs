using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost,1472; Initial Catalog = MultiShopCommentDb; TrustServerCertificate=True; MultipleActiveResultSets=true; User ID = sa; Password=123456aA*;");
        }

        public DbSet<UserComment> UserCommnets { get; set; }

    }
}
