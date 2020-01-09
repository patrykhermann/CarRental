using CarRental.API.DbContexts;
using CarRental.API.Entities;
using CarRental.API.Helpers;
using CarRental.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.API.Services
{
    public class CarRentalRepository : ICarRentalRepository
    {
        private readonly CarRentalContext _context;

        public CarRentalRepository(CarRentalContext context)
        {
            _context = context;
        }

        public void AddCar(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            car.Id = Guid.NewGuid();

            _context.Cars.Add(car);
        }

        public void AddClient(Client client)
        {
            if(client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            client.Id = Guid.NewGuid();

            foreach(var rental in client.Rentals)
            {
                rental.Id = Guid.NewGuid();
            }

            _context.Clients.Add(client);
        }

        public void AddRental(Rental rental)
        {
            if (rental == null)
            {
                throw new ArgumentNullException(nameof(rental));
            }

            rental.Id = Guid.NewGuid();
            rental.Car.Id = Guid.NewGuid();
            rental.Client.Id = Guid.NewGuid();
            rental.FullPrice = RentalPriceCalculator.CalculateFullPrice(rental);
            
            _context.Rentals.Add(rental);
        }

        public bool CarExists(Guid carId)
        {
            if (carId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(carId));
            }

            return _context.Cars.Any(c => c.Id == carId);
        }

        public bool ClientExists(Guid clientId)
        {
            if (clientId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            return _context.Clients.Any(c => c.Id == clientId);
        }

        public void DeleteCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            _context.Cars.Remove(car);
        }

        public void DeleteClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Clients.Remove(client);
        }

        public void DeleteRental(Rental rental)
        {
            if (rental == null)
            {
                throw new ArgumentNullException(nameof(rental));
            }

            _context.Rentals.Remove(rental);
        }

        public Car GetCar(Guid carId)
        {
            if (carId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(carId));
            }

            return _context.Cars.FirstOrDefault(c => c.Id == carId);
        }

        public IEnumerable<Car> GetCars(CarsResourceParameters carsResourceParameters)
        {
            var collection = _context.Cars as IQueryable<Car>;

            // Filtering
            if(!string.IsNullOrWhiteSpace(carsResourceParameters.Brand))
            {
                var brand = carsResourceParameters.Brand.Trim();
                collection = collection.Where(c => c.Brand == brand);
            }

            if(!string.IsNullOrWhiteSpace(carsResourceParameters.PricePerDay))
            {
                var pricePerDay = decimal.Parse(carsResourceParameters.PricePerDay.Trim());
                collection = collection.Where(c => c.PricePerDay == pricePerDay);
            }

            //Searching
            if(!string.IsNullOrWhiteSpace(carsResourceParameters.SearchQuery))
            {
                var searchQuery = carsResourceParameters.SearchQuery.Trim();
                collection = collection.Where(c => c.Brand.Contains(searchQuery) || c.Model.Contains(searchQuery));
            }

            return collection.ToList();
        }

        public Client GetClient(Guid clientId)
        {
            if (clientId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            return _context.Clients.FirstOrDefault(c => c.Id == clientId);
        }

        public IEnumerable<Client> GetClients(ClientsResourceParameters clientsResourceParameters)
        {
            var collection = _context.Clients as IQueryable<Client>;

            if(!string.IsNullOrWhiteSpace(clientsResourceParameters.SearchQuery))
            {
                var searchQuery = clientsResourceParameters.SearchQuery.Trim();
                collection = collection.Where(c => c.FirstName.Contains(searchQuery) || c.LastName.Contains(searchQuery));
            }

            return collection.ToList();
        }

        public Rental GetRental(Guid rentalId)
        {
            if (rentalId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rentalId));
            }

            return _context.Rentals.FirstOrDefault(r => r.Id == rentalId);
        }

        public IEnumerable<Rental> GetRentals()
        {
            return _context.Rentals.ToList();
        }

        public bool RentalExists(Guid rentalId)
        {
            if (rentalId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(rentalId));
            }

            return _context.Rentals.Any(r => r.Id == rentalId);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateCar(Car car)
        {
            // No code in this implementation 
        }

        public void UpdateClient(Client client)
        {
            // No code in this implementation 
        }

        public void UpdateRental(Rental rental)
        {
            // No code in this implementation 
        }
    }
}
