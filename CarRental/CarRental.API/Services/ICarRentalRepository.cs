using CarRental.API.Entities;
using System;
using System.Collections.Generic;

namespace CarRental.API.Services
{
    public interface ICarRentalRepository
    {
        Client GetClient(Guid clientId);
        IEnumerable<Client> GetClients();
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        bool ClientExists(Guid clientId);
        IEnumerable<Car> GetCars();
        Car GetCar(Guid carId);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
        bool CarExists(Guid carId);
        IEnumerable<Rental> GetRentals();
        Rental GetRental(Guid rentalId);
        void AddRental(Rental rental);
        void UpdateRental(Rental rental);
        void DeleteRental(Rental rental);
        bool RentalExists(Guid rentalId);
        bool Save();
    }
}
