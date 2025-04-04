﻿namespace Microservices.Common.Commands
{
    public class CreateActivity : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        Guid IAuthenticatedCommand.Userid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
