using System;

namespace CarRental.API.Models
{
    public class RentalDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset PickUpDate { get; set; }
        public DateTimeOffset DropOffDate { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public decimal FullPrice { get; set; }
        public string Car { get; set; }
        public string Client { get; set; }
    }
}
