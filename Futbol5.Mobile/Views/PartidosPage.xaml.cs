namespace Futbol5.Mobile.Views;

public partial class PartidosPage : ContentPage
{
    public PartidosPage()
    {
        InitializeComponent();
    }

    private async void OnCrearPartido(object sender, EventArgs e)
    {
        await DisplayAlert("Info", "Crear partido próximamente", "OK");
    }
}