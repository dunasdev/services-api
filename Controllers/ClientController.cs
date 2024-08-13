using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Api.Contexts;
using Services.Api.DTOs;
using Services.Api.Models;

namespace Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetAllClients()
        {
            var clients = _context.Clients.ToList();
        
            return Ok(clients);
        }

        [HttpGet("{Id}")]
        public IActionResult GetClient(Guid id) {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient([FromBody] CreateClientDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Client = new Client
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone1 = dto.Phone1,
                Phone2 = dto.Phone2,
                StoreId = Guid.Parse("ea46d159-8124-4f12-96ec-d2a8546ede9d")
            };

            _context.Clients.Add(Client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClient), new { id = Client.Id }, Client);
        }
    }
}
