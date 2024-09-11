namespace Microservices.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid Userid { get; set; }

    }
}
