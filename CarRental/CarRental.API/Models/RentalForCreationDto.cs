using System;
using System.ComponentModel.DataAnnotations;
using CarRental.API.ValidationAttributes;

namespace CarRental.API.Models
{
    [DropOffDateMustBeGreaterThanPickUpDate(ErrorMessage = "Drop-off Date must be greater than Pick-up Date")]
    public class RentalForCreationDto
    {
        [Required]
        public DateTimeOffset PickUpDate { get; set; }

        [Required]
        public DateTimeOffset DropOffDate { get; set; }
        
        [Required]
        public string PickUpLocation { get; set; }
        
        [Required]
        public string DropOffLocation { get; set; }
        
        [Range(0,100)]
        public int Discount { get; set; } = 0;
        
        public CarForCreationDto Car { get; set; } = new CarForCreationDto();
        public ClientForCreationDto Client { get; set; } = new ClientForCreationDto();
    }
}
