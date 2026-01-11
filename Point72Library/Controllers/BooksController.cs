using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Point72Library.Data;
using Point72Library.Models;

namespace Point72Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks() 
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book, int librarianId)
        {
            var librarian = await _context.Clients.FindAsync(librarianId);
            if (librarian == null || !librarian.IsLibrarian)
                return Unauthorized("Only librarians can add books");

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllBooks), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, int librarianId)
        {
            var librarian = await _context.Clients.FindAsync(librarianId);
            if (librarian == null || !librarian.IsLibrarian)
                return Unauthorized("Only librarians can remove books");

            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
