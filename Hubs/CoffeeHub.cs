using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace what_is_endpoint.Hubs
{
    ///This is a class that contains method that can be called by
    ///client
    public class CoffeeHub : Hub
    {
        public CoffeeHub()
        {
        }

        public async override Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,"All");
        }

        public void PlaceOrder()
        {
            System.Console.WriteLine("order placed");;
        }
    }
}