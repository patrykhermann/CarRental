using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.API.Entities
{
    public class Rental
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTimeOffset PickUpDate { get; set; }

        [Required]
        public DateTimeOffset DropOffDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string PickUpLocation { get; set; }

        [Required]
        [MaxLength(50)]
        public string DropOffLocation { get; set; }

        [Required]
        public decimal FullPrice { get; set; }

        public int Discount { get; set; } = 0;

        [ForeignKey("CarId")]
        public Car Car { get; set; }
        public Guid CarId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public Guid ClientId { get; set; }

    }
}
