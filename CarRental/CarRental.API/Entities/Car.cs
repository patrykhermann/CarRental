using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.API.Entities
{
    public class Car
    {
        [Required]
        public Guid Id { get; set; }

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
