﻿using Microservices.Common.Commands;
using Microservices.Common.Events;
using RawRabbit;

namespace Microservices.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;

        public CreateActivityHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }
        public async Task HandleAsync(CreateActivity command)
        {
            Console.WriteLine($"YawZaa Creating activity: {command.Name}");
            await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category
                , command.Name, command.Description, command.CreatedAt));
        }
    }
}
