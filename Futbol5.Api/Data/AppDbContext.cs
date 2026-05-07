using Futbol5.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Futbol5.Api.Data
{
  

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Gol> Goles { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        public DbSet<Torneo> Torneos { get; set; }
    }
}
