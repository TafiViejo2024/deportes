using Futbol5.Mobile.Models;
using System.Text.Json;

namespace Futbol5.Mobile.Views;

public partial class TorneosPage : ContentPage
{
    HttpClient http = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7297/")
    };

    public TorneosPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await CargarTorneos();
    }

    private async Task CargarTorneos()
    {
        try
        {
            var response = await http.GetAsync("api/Torneos");

            if (!response.IsSuccessStatusCode)
            {
                await DisplayAlert(
                    "Error",
                    "No se pudieron cargar los torneos",
                    "OK");

                return;
            }

            var json = await response.Content.ReadAsStringAsync();

            var torneos = JsonSerializer.Deserialize<List<Torneo>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            // URL completa imágenes
            //foreach (var torneo in torneos)
            //{
            //    if (!string.IsNullOrEmpty(torneo.ImagenUrl))
            //    {
            //        torneo.ImagenUrl =
            //            "https://localhost:7297" + torneo.ImagenUrl;
            //    }
            //}

            TorneosList.ItemsSource = torneos;
        }
        catch (Exception ex)
        {
            await DisplayAlert(
                "Error",
                ex.Message,
                "OK");
        }
    }

    private async void OnNuevoTorneo(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(
            new CrearTorneoPage());
    }
}