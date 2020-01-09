using System.ComponentModel.DataAnnotations;

namespace CarRental.API.Models
{
    public class CarForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }
    }
}
