namespace Futbol5.Api.Dtos
{
    //public class CrearTorneoDto
    //{
    //    public string Nombre { get; set; }

    //    public string Tipo { get; set; }

    //    public int CantidadEquipos { get; set; }

    //    public DateTime FechaInicio { get; set; }

    //    public DateTime? FechaFin { get; set; }

    //    public IFormFile? Imagen { get; set; }
    //}

    public class CrearTorneoDto
    {
        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public string? Tipo { get; set; }

        public int? CantidadEquipos { get; set; }

        public IFormFile? Imagen { get; set; }
    }
}
