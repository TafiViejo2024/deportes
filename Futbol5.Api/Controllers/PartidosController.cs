using Futbol5.Api.Data;
using Futbol5.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Futbol5.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartidosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PartidosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Partidos.ToList());

        [HttpPost]
        public async Task<IActionResult> Create(Partido partido)
        {
            _context.Partidos.Add(partido);
            await _context.SaveChangesAsync();
            return Ok(partido);
        }
    }
}
