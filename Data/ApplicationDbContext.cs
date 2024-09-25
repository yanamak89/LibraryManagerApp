using LibraryManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApp.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
}