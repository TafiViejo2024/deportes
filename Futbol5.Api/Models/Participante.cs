namespace Futbol5.Api.Models
{
    public class Participante
    {
        public int Id { get; set; }
        public int PartidoId { get; set; }
        public int UsuarioId { get; set; }
        public string Equipo { get; set; }
    }
}
