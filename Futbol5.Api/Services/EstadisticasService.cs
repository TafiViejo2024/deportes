using Futbol5.Api.Data;

namespace Futbol5.Api.Services
{
    public class EstadisticasService
    {
        private readonly AppDbContext _context;

        public EstadisticasService(AppDbContext context)
        {
            _context = context;
        }

        public int GolesPorJugador(int usuarioId)
        {
            return _context.Goles.Count(g => g.UsuarioId == usuarioId);
        }
    }
}
