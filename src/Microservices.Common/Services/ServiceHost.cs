using Microservices.Common.Commands;
using Microservices.Common.Events;
using Microservices.Common.RabbitMq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using ICommand = Microservices.Common.Commands.ICommand;

namespace Microservices.Common.Services
{
    public class ServiceHost : IServiceHost
    {
        private readonly IWebHost _webHost;

        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }
        public void Run() => _webHost.Start();

        public static HostBuilder Create<Tstartup>(string[] args) where Tstartup : class
        {
            Console.Title = typeof(Tstartup).Namespace;
            var config = new ConfigurationBuilder()
                            .AddEnvironmentVariables()
                            .AddCommandLine(args)
                            .Build();

            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<Tstartup>();


            return new HostBuilder(webHostBuilder.Build());
        }

        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();

        }

        public class HostBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IBusClient _bus;
            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            public BusBuilder UseRabbitMq()
            {
                _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));

                return new BusBuilder(_webHost, _bus);
            }
            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }

        public class BusBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IBusClient _bus;
            public BusBuilder(IWebHost webHost, IBusClient busClient)
            {
                _webHost = webHost;
                _bus = busClient;
            }

            public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                var handler = (ICommandHandler<TCommand>)_webHost.Services
                    .GetService(typeof(ICommandHandler<TCommand>));
                _bus.WithCommandHandlerAsync(handler);

                return this;
            }



            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var handler = (IEventHandler<TEvent>)_webHost.Services
                    .GetService(typeof(IEventHandler<TEvent>));
                _bus.WithEventHandlerAsync(handler);

                return this;
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }

    }
}
