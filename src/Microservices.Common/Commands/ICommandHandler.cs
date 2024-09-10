namespace Microservices.Common.Commands
{
    internal interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
