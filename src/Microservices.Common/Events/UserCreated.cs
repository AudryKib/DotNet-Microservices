namespace Microservices.Common.Events
{
    public class UserCreated : IEvents
    {
        public string Email { get; }
        public string Name { get; }

        protected UserCreated()
        {
        }

        public UserCreated(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
