global using Microsoft.EntityFrameworkCore;
using Small_API.Models;

namespace Small_API.Data
{
    public class DataContext : DbContext
    {
       protected readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("SmallAPIDatabase"));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Content>()
        //        .HasOne(c => c.Section)
        //        .WithOne(s => s.Content)
        //        .HasForeignKey<Section>(s => s.ContentId);
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
