namespace Futbol5.Api.Dtos
{   
    public class TorneoCreateDto
    {
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public IFormFile? Imagen { get; set; }
    }
}
