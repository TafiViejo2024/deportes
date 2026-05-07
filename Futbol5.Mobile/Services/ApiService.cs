using System;
using System.Collections.Generic;
using System.Text;
using Futbol5.Mobile.Models;
using System.Net.Http.Json;


namespace Futbol5.Mobile.Services
{
   
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7297/") // 👈 tu API
            };
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            return await _http.GetFromJsonAsync<List<Usuario>>("api/usuarios");
        }

        public async Task CrearUsuario(Usuario usuario)
        {
            await _http.PostAsJsonAsync("api/usuarios", usuario);
        }
    }
}
