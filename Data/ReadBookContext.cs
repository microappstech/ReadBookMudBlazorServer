using Microsoft.EntityFrameworkCore;
using ReadBookMuds.Models;

namespace ReadBookMuds.Data
{
    public class ReadBookContext:DbContext 
    {
        public ReadBookContext(DbContextOptions<ReadBookContext> dbContextOptions):base(dbContextOptions)
        {   
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
                .Property(c => c.DateAdd)
                .HasColumnType("datetime");
            builder.Entity<Book>().
                HasKey(i => i.Id);
            builder.Entity<Category>().
                HasKey(c => c.Id);

            builder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .HasPrincipalKey(c => c.Id);

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
