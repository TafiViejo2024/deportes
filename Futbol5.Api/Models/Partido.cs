namespace Futbol5.Api.Models
{
    public class Partido
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Estado { get; set; } = "Pendiente";

        // 👇 CLAVE
        public int? TorneoId { get; set; }
        public Torneo? Torneo { get; set; }
    }
}
