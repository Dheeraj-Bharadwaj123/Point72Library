using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Point72Library.Data;
using Point72Library.Models;

namespace Point72Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LoansController(LibraryContext context)
        {
            _context = context;
        }
        
        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook(int bookId, int clientId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null) return NotFound("Book not found");

            var client = await _context.Clients.FindAsync(clientId);
            if (client == null) return NotFound("Client not found");

            var loan = new Loan { BookId = bookId, ClientId = clientId };
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return Ok(loan);

        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook(int loanId)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan == null) return NotFound("Loan not found");
            if (loan.Returned) return BadRequest("Book already returned");

            loan.Returned = true;
            await _context.SaveChangesAsync();
            return Ok(loan);
        }
    }
}
