using System;
using System.Collections.Generic;
using System.Text;

namespace Futbol5.Mobile.Models
{
    using System.IO;
    using System.Text.Json.Serialization;

    public class Torneo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public string Estado { get; set; }

        public string? Tipo { get; set; }

        public int? CantidadEquipos { get; set; }

        [JsonPropertyName("imagenBase64")]
        public string? ImagenBase64 { get; set; }

        // Imagen lista para MAUI
        public ImageSource ImagenSource
        {
            get
            {
                if (string.IsNullOrEmpty(ImagenBase64))
                    return null;

                byte[] bytes =
                    Convert.FromBase64String(ImagenBase64);

                return ImageSource.FromStream(() =>
                    new MemoryStream(bytes));
            }
        }
    }
}
