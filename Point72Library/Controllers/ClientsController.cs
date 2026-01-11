using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Point72Library.Models;
using Point72Library.Data;

namespace Point72Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController: ControllerBase
    {
        private readonly LibraryContext _context;

        public ClientsController(LibraryContext context) 
        { 
            _context = context;
        }
            
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllClients), new { id = client.Id }, client);
        }
    }
}
