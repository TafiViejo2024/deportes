namespace Futbol5.Api.Models
{
    public class Torneo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public string Estado { get; set; } = "Activo";

        public string? ImagenUrl { get; set; }

        // 🔽 NUEVOS (recomendados)
        public string? Tipo { get; set; } // Liga, Eliminación, etc.

        public int? CantidadEquipos { get; set; }

        public int? UsuarioCreadorId { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
