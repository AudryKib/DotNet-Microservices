namespace Microservices.Api.Models
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}