using Microsoft.EntityFrameworkCore;
using Point72Library.Models;

namespace Point72Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Client> Clients { get; set; } = null!;

        public DbSet<Loan> Loans { get; set; } = null!;
    }
}
