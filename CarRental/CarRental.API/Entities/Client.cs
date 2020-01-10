using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRental.API.Entities
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }

        [Required]
        [RegularExpression("^\\d{9}$")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Rental> Rentals { get; set; }
            = new List<Rental>();
    }
}
