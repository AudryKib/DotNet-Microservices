
using Microservices.Common.Commands;
using Microservices.Common.Services;

namespace Microservices.Services.Identity
{
    public class Program
    {


        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Identity Service...");

            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<CreateUser>()
                .Build()
                .Run();

            Console.WriteLine("Identity Service Running...");
        }
    }

}