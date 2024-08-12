using System.ComponentModel.DataAnnotations;

namespace Services.Api.Models
{
    public class Service
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public DateTime Deadline {  get; set; }
        public Guid ClientId { get; set; }
        public Guid WorkerId { get; set; }
        public Guid StoreId { get; set; }
        public Client? Client { get; set; }
        public Worker? Worker { get; set; }
        public Store? Store { get; set; }
    }
}
