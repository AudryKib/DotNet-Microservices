namespace Microservices.Common.Events
{
    public class UserAuthenticated
    {
        public string Email { get; }

        protected UserAuthenticated()
        {
        }

        public UserAuthenticated(string email)
        {
            Email = email;
        }

    }
}
