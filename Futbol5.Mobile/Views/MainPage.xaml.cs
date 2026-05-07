using Futbol5.Mobile.Models;
using Futbol5.Mobile.Services;
using Futbol5.Mobile.ViewModels;

namespace Futbol5.Mobile.Views;

public partial class MainPage : ContentPage
{
    private UsuariosViewModel _vm = new();

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCargarClicked(object sender, EventArgs e)
    {
        await _vm.CargarUsuarios();
        UsuariosList.ItemsSource = _vm.Usuarios;
    }
    private async void OnAgregarClicked(object sender, EventArgs e)
    {
        var nombre = await DisplayPromptAsync("Nuevo jugador", "Nombre:");

        if (!string.IsNullOrEmpty(nombre))
        {
            var usuario = new Usuario { Nombre = nombre };
            await new ApiService().CrearUsuario(usuario);

            await _vm.CargarUsuarios();
            UsuariosList.ItemsSource = _vm.Usuarios;
        }
    }
}
