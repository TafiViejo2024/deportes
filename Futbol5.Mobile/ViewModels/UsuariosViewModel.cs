using System;
using System.Collections.Generic;
using System.Text;
using Futbol5.Mobile.Models;
using Futbol5.Mobile.Services;
using System.Collections.ObjectModel;

namespace Futbol5.Mobile.ViewModels
{
   

    public class UsuariosViewModel
    {
        private readonly ApiService _api;

        public ObservableCollection<Usuario> Usuarios { get; set; } = new();

        public UsuariosViewModel()
        {
            _api = new ApiService();
        }

        public async Task CargarUsuarios()
        {
            var lista = await _api.ObtenerUsuarios();

            Usuarios.Clear();
            foreach (var u in lista)
                Usuarios.Add(u);
        }
    }
}
