using System.Net.Http;

namespace Futbol5.Mobile.Views;

public partial class CrearTorneoPage : ContentPage
{
    FileResult _imagen;

    public CrearTorneoPage()
    {
        InitializeComponent();
    }

    private async void OnSeleccionarImagen(object sender, EventArgs e)
    {
        _imagen = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images
        });

        if (_imagen != null)
        {
            PreviewImagen.Source = ImageSource.FromFile(_imagen.FullPath);
        }
    }

    private async void OnCrearTorneo(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(NombreEntry.Text))
            {
                await DisplayAlert("Error", "El nombre es obligatorio", "OK");
                return;
            }

            var content = new MultipartFormDataContent();

            content.Add(new StringContent(NombreEntry.Text), "Nombre");

            content.Add(new StringContent(
                FechaInicioPicker.Date.ToString()), "FechaInicio");

            // Fecha fin opcional (simple)
            if (FechaFinPicker.Date > FechaInicioPicker.Date)
            {
                content.Add(new StringContent(
                    FechaFinPicker.Date.ToString()), "FechaFin");
            }

            // Imagen
            if (_imagen != null)
            {
                var stream = await _imagen.OpenReadAsync();
                var streamContent = new StreamContent(stream);

                streamContent.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

                content.Add(streamContent, "Imagen", _imagen.FileName);
            }

            var http = new HttpClient
            {
                BaseAddress = new Uri("https://10.0.2.2:7297/") // 👈 Android fix
            };

            var response = await http.PostAsync("api/torneos/con-imagen", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("OK", "Torneo creado", "OK");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo crear el torneo", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnCancelar(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}