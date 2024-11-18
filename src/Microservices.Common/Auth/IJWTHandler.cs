namespace Microservices.Common.Auth
{
    public interface IJWTHandler
    {
        JsonWebToken Create(Guid userId);
    }
}
