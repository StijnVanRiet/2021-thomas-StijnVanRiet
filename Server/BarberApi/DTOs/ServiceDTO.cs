using System.ComponentModel.DataAnnotations;

namespace BarberApi.DTOs
{
    public class ServiceDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double? Price { get; set; }
    }
}
