namespace Futbol5.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string GoogleId { get; set; } // 👈 clave única
    }
}
