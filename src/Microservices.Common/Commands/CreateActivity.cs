namespace Microservices.Common.Commands
{
    internal class CreateActivity : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public Guid Userid { get; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        Guid IAuthenticatedCommand.Userid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
