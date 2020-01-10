using CarRental.API.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.API.Models
{
    [DropOffDateMustBeGreaterThanPickUpDate(ErrorMessage = "Drop-off Date must be greater than Pick-up Date")]
    public abstract class RentalForManipulationDto
    {
        [Required]
        public DateTimeOffset PickUpDate { get; set; }

        [Required]
        public DateTimeOffset DropOffDate { get; set; }

        [Required]
        public string PickUpLocation { get; set; }

        [Required]
        public string DropOffLocation { get; set; }

        [Range(0, 100)]
        public int Discount { get; set; } = 0;

        [Required]
        public CarForCreationDto Car { get; set; }

        [Required]
        public ClientForCreationDto Client { get; set; }
    }
}
