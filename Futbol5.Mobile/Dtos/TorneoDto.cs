using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol5.Mobile.Dtos
{
    public class TorneoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }

        public string Estado { get; set; }

        // URL pública de imagen
        // Imagen en Base64
        public string? ImagenBase64 { get; set; }
    }
}
