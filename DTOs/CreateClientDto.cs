using System.ComponentModel.DataAnnotations;

namespace Services.Api.DTOs
{
    public class CreateClientDto
    {
        [Required] [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required] [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required] [MaxLength(20)]
        public string Phone1 { get; set; } = string.Empty;
        [Required] [MaxLength(20)]
        public string Phone2 { get; set; } = string.Empty;
    }
}
