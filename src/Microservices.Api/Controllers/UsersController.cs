using Microservices.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Microservices.Api.Controllers
{

    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IBusClient _busClient;

        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Microservice API!, This is the User Controller");

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            Console.WriteLine("CreateUser command received");

            await _busClient.PublishAsync(command);

            return Accepted();
        }
    }
}
