using Microsoft.AspNetCore.SignalR;
namespace Futbol5.Api.Hubs
{
    public class PartidoHub : Hub
    {
        public async Task NotificarGol(object gol)
        {
            await Clients.All.SendAsync("golRegistrado", gol);
        }
    }
}
