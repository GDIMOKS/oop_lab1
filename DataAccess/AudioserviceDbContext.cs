using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class AudioserviceDbContext : DbContext
    {
        public AudioserviceDbContext()
        {
            
        }
        public AudioserviceDbContext(DbContextOptions<AudioserviceDbContext> options) : base(options)
        {
            
        }

        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Collection> Collections { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=oop;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasAlternateKey(a => a.Name);
            modelBuilder.Entity<Category>().HasAlternateKey(c => c.Name);

        }
    } 
}
