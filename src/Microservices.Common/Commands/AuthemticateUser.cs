namespace Microservices.Common.Commands
{
    internal class AuthemticateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
