using System.ComponentModel.DataAnnotations;

namespace Services.Api.Models
{
    public class Store
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Service> Services { get; set; } = new List<Service>();
        public List<Worker> Workers { get; set; } = new List<Worker>();
        public List<Client> Clients { get; set; } = new List<Client>();
    }
}
