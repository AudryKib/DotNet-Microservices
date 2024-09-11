using Microservices.Common.Commands;
using Microservices.Common.Events;
using RawRabbit;
using System.Reflection;

namespace Microservices.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg =>
                    // Multiple instances of same service should subscribe to same single queue.
                    cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg =>
                    // Multiple instances of same service should subscribe to same single queue.
                    cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));


        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
    }
}
