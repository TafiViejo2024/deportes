namespace Futbol5.Mobile.Views;

public partial class TorneosPage : ContentPage
{

    
    public TorneosPage()
    {
        InitializeComponent();
    }

    FileResult _imagen;

    private async void OnNuevoTorneo(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CrearTorneoPage());
    }


    

}