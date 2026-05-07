namespace Futbol5.Api.Models
{
    public class Gol
    {
        public int Id { get; set; }
        public int PartidoId { get; set; }
        public int UsuarioId { get; set; }
        public int Minuto { get; set; }
    }
}
