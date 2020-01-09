using CarRental.API.Entities;

namespace CarRental.API.Helpers
{
    public static class RentalPriceCalculator
    {
        public static decimal CalculateFullPrice(Rental rental)
        {
            var pickUpDate = rental.PickUpDate;
            var dropOffDate = rental.DropOffDate;
            var pricePerDay = rental.Car.PricePerDay;

            var daysDifference = (dropOffDate - pickUpDate).Days;

            if (dropOffDate.Hour != pickUpDate.Hour)
            {
                daysDifference++;
            }
            else if (dropOffDate.Hour == pickUpDate.Hour && dropOffDate.Minute != pickUpDate.Minute)
            {
                daysDifference++;
            }

            var rentalPrice = daysDifference * pricePerDay;
            var discountPrice = ApplyDiscount(rentalPrice, rental.Discount);

            return discountPrice;
        }

        private static decimal ApplyDiscount(decimal price, int discount)
        {
            return price * (100 - discount) / 100;
        }
    }
}
