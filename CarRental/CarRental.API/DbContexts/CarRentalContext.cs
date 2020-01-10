using CarRental.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarRental.API.DbContexts
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed db
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = Guid.Parse("01b1df53-aa1e-4de3-94e8-fc5db416d1ab"),
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    DateOfBirth = new DateTime(1972, 01, 20),
                    Email = "jan.kowalski@gmail.com",
                    PhoneNumber = "123456789"
                },
                new Client
                {
                    Id = Guid.Parse("b703b28b-f6a3-48a7-bc30-843e1432067f"),
                    FirstName = "Piotr",
                    LastName = "Nowak",
                    DateOfBirth = new DateTime(1990, 07, 02),
                    Email = "piotr.nowak@gmail.com",
                    PhoneNumber = "123456789"
                },
                new Client
                {
                    Id = Guid.Parse("0b52188f-6c5d-4b88-aaa9-bb0b977191b2"),
                    FirstName = "Wojciech",
                    LastName = "Mazur",
                    DateOfBirth = new DateTime(1962, 03, 11),
                    Email = "w.mazur@gmail.com",
                    PhoneNumber = "123456789"
                },
                new Client
                {
                    Id = Guid.Parse("63c8753b-31a6-4cda-be54-344285573086"),
                    FirstName = "Artur",
                    LastName = "Żółć",
                    DateOfBirth = new DateTime(1987, 12, 23),
                    Email = "a.zolc@gmail.com",
                    PhoneNumber = "123456789"
                },
                new Client
                {
                    Id = Guid.Parse("c89e32ee-b112-468f-8f35-47dd669c4476"),
                    FirstName = "Ryszard",
                    LastName = "Malinowski",
                    DateOfBirth = new DateTime(1969, 08, 03),
                    Email = "ryszard_malinowski@gmail.com",
                    PhoneNumber = "123456789"
                },
                new Client
                {
                    Id = Guid.Parse("39d51b08-4175-4a35-83ef-764385e33b4a"),
                    FirstName = "Kacper",
                    LastName = "Nowicki",
                    DateOfBirth = new DateTime(1992, 04, 13),
                    Email = "k.nowicki@gmail.com",
                    PhoneNumber = "123456789"
                });

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = Guid.Parse("55c1b270-2b89-481a-8efe-43e4c1d8a083"),
                    Brand = "Skoda",
                    Model = "Citigo",
                    PricePerDay = 59
                },
                new Car
                {
                    Id = Guid.Parse("4027a68c-5cf7-4b07-9fbd-fdd2fec85e5c"),
                    Brand = "Opel",
                    Model = "Corsa",
                    PricePerDay = 89
                },
                new Car
                {
                    Id = Guid.Parse("1399ac00-8d3c-40e6-82a6-218ad13613ba"),
                    Brand = "Skoda",
                    Model = "Fabia",
                    PricePerDay = 89
                },
                new Car
                {
                    Id = Guid.Parse("5bf2ce55-2f36-426d-b6b8-1243532b7700"),
                    Brand = "Opel",
                    Model = "Astra",
                    PricePerDay = 109
                },
                new Car
                {
                    Id = Guid.Parse("ce6cb2d4-a123-4958-82eb-96d13d961219"),
                    Brand = "Seat",
                    Model = "Leon",
                    PricePerDay = 109
                },
                new Car
                {
                    Id = Guid.Parse("29c4e1e9-1689-4c3f-9546-2ba17c6f4219"),
                    Brand = "Volkswagen",
                    Model = "Passat",
                    PricePerDay = 149
                },
                new Car
                {
                    Id = Guid.Parse("ae939b70-1834-4ece-8cda-182694c2b6e8"),
                    Brand = "Kia",
                    Model = "Sportage",
                    PricePerDay = 169
                },
                new Car
                {
                    Id = Guid.Parse("28439609-b9a3-46c5-85d3-fa9de41b93c2"),
                    Brand = "BMW",
                    Model = "530",
                    PricePerDay = 229
                });

            modelBuilder.Entity<Rental>().HasData(
                new Rental
                {
                    Id = Guid.Parse("ca96e8a7-2b4d-43af-90d1-09b701473c4c"),
                    PickUpDate = new DateTime(2020, 1, 20, 10, 0, 0),
                    DropOffDate = new DateTime(2020, 1, 27, 10, 0, 0),
                    PickUpLocation = "Poznań, lotnisko Ławica",
                    DropOffLocation = "Warszawa, lotnisko Chopina",
                    FullPrice = 623,
                    CarId = Guid.Parse("4027a68c-5cf7-4b07-9fbd-fdd2fec85e5c"),
                    ClientId = Guid.Parse("0b52188f-6c5d-4b88-aaa9-bb0b977191b2")
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}