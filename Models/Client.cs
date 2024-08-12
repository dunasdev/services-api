using System.ComponentModel.DataAnnotations;

namespace Services.Api.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone1 { get; set; } = string.Empty;
        public string Phone2 { get; set; } = string.Empty;
        public Guid StoreId { get; set; }
        public Store? Store { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();
    }
}
