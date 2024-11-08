using Microservices.Common.Commands;

namespace Microservices.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        public Task HandleAsync(CreateUser command)
        {
            throw new NotImplementedException();
        }
    }
}
