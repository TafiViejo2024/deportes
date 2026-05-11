namespace Futbol5.Api.Dtos
{
    public class TorneoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }

        public string Estado { get; set; }

        // Imagen en Base64
        public string? ImagenBase64 { get; set; }
    }
}
