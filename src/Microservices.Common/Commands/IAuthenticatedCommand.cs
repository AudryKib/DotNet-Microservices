namespace Microservices.Common.Commands
{
    internal interface IAuthenticatedCommand : ICommand
    {
        Guid Userid { get; set; }

    }
}
