using Microservices.Common.Commands;
using Microservices.Common.Events;
using Microservices.Common.Exceptions;
using Microservices.Services.Identity.Domain.Services;
using RawRabbit;

namespace Microservices.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IBusClient busClient, IUserService userService, ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _userService = userService;
            _logger = logger;
        }
        public async Task HandleAsync(CreateUser command)
        {

            _logger.LogInformation($"Creating user: '{command.Email}' with name: '{command.Name}'.");

            try
            {
                await _userService.RegisterAsync(command.Email, command.Password, command.Name);
                await _busClient.PublishAsync(new UserCreated(command.Email, command.Name));

                return;
            }

            catch (MicroException ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, ex.Code, ex.Message));
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, "error", ex.Message));
                _logger.LogError(ex.Message);
            }
        }
    }
}
