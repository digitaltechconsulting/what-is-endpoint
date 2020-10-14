using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using what_is_endpoint.Hubs;
using System.Threading.Tasks;

namespace what_is_endpoint.Controllers
{
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
        private readonly IHubContext<CoffeeHub> _hubContext;
        public ApiController(IHubContext<CoffeeHub> hubContext)
        {
           _hubContext = hubContext; 
        }
        public async Task<IActionResult> Get()
        {
            System.Console.WriteLine("inside get request");
            await _hubContext.Clients.All.SendAsync("updateReceived","test update");
            return Ok("event sent");
        }
    }
}