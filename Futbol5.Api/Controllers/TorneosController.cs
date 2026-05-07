using Futbol5.Api.Data;
using Futbol5.Api.Dtos;
using Futbol5.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Futbol5.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorneosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TorneosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Torneos.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Torneo torneo)
        {
            _context.Torneos.Add(torneo);
            await _context.SaveChangesAsync();
            return Ok(torneo);
        }

        [HttpPost("con-imagen")]
        public async Task<IActionResult> CrearConImagen([FromForm] TorneoCreateDto dto)
        {
            string? filePath = null;

            if (dto.Imagen != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(dto.Imagen.FileName);
                var path = Path.Combine("wwwroot/images", fileName);

                Directory.CreateDirectory("wwwroot/images");

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await dto.Imagen.CopyToAsync(stream);
                }

                filePath = "/images/" + fileName;
            }

            var torneo = new Torneo
            {
                Nombre = dto.Nombre,
                FechaInicio = dto.FechaInicio,
                ImagenUrl = filePath
            };

            _context.Torneos.Add(torneo);
            await _context.SaveChangesAsync();

            return Ok(torneo);
        }
    }
}
