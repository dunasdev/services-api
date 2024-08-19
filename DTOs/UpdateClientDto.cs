using System.ComponentModel.DataAnnotations;

namespace Services.Api.DTOs
{
    public class UpdateClientDto
    {
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? Phone1 { get; set; }
        [MaxLength(20)] 
        public string? Phone2 { get; set; }
    }
}
