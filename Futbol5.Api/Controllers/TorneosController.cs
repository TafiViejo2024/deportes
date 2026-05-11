using Futbol5.Api.Data;
using Futbol5.Api.Dtos;
using Futbol5.Api.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Get()
        {
            var torneos = await _context.Torneos.ToListAsync();

            var resultado = torneos.Select(t => new TorneoDto
            {
                Id = t.Id,
                Nombre = t.Nombre,
                FechaInicio = t.FechaInicio,
                Estado = t.Estado,

                ImagenBase64 = t.Imagen != null
                    ? Convert.ToBase64String(t.Imagen)
                    : null
            });

            return Ok(resultado);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromForm] CrearTorneoDto dto)
        //{
        //    var torneo = new Torneo
        //    {
        //        Nombre = dto.Nombre,
        //        FechaInicio = dto.FechaInicio,
        //        FechaFin = dto.FechaFin,
        //        Tipo = dto.Tipo,
        //        CantidadEquipos = dto.CantidadEquipos
        //    };

        //    _context.Torneos.Add(torneo);

        //    await _context.SaveChangesAsync();

        //    return Ok(torneo);
        //}

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Crear(
         [FromForm] CrearTorneoDto dto)
        {
            byte[]? imagenBytes = null;

            // Imagen opcional
            if (dto.Imagen != null)
            {
                using var memoryStream = new MemoryStream();

                await dto.Imagen.CopyToAsync(memoryStream);

                imagenBytes = memoryStream.ToArray();
            }

            var torneo = new Torneo
            {
                Nombre = dto.Nombre,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Tipo = dto.Tipo,
                CantidadEquipos = dto.CantidadEquipos,

                // Guardar bytes en SQL
                Imagen = imagenBytes
            };

            _context.Torneos.Add(torneo);

            await _context.SaveChangesAsync();

            return Ok(torneo);
        }
    }
}
