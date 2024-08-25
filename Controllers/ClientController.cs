using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Api.Contexts;
using Services.Api.DTOs;
using Services.Api.Models;
using System.Security.Claims;

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

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateClient(string id, [FromBody] UpdateClientDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Nenhum dado para atualizar");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == Guid.Parse(id));

            if (client == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(dto.Name))
            {
                client.Name = dto.Name;
            }

            if (!string.IsNullOrEmpty(dto.Email))
            {
                client.Email = dto.Email;
            }

            if (!string.IsNullOrEmpty(dto.Phone1))
            {
                client.Phone1 = dto.Phone1;
            }

            if (!string.IsNullOrEmpty(dto.Phone2))
            {
                client.Phone2 = dto.Phone2;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(s => s.Id == Guid.Parse(id));

            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
