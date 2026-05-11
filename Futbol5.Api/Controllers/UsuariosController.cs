using Futbol5.Api.Data;
using Futbol5.Api.Dtos;
using Futbol5.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Futbol5.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Usuarios.ToList());

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginDto dto)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.GoogleId == dto.GoogleId);

            if (usuario == null)
            {
                usuario = new Usuario
                {
                    Nombre = dto.Nombre,
                    Email = dto.Email,
                    GoogleId = dto.GoogleId
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
            }

            return Ok(usuario);
        }
    }
}
