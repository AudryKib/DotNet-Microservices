namespace Microservices.Services.Identity.Domain.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password, string name);
        Task LoginAsync(string email, string password);
    }
}
