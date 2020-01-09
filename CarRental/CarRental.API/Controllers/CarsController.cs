using CarRental.API.Entities;
using CarRental.API.ResourceParameters;
using CarRental.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRentalRepository _carRentalRepository;

        public CarsController(ICarRentalRepository carRentalRepository)
        {
            _carRentalRepository = carRentalRepository;
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<Car>> GetCars([FromQuery]CarsResourceParameters carsResourceParameters)
        {
            var carsFromRepo = _carRentalRepository.GetCars(carsResourceParameters);
            return Ok(carsFromRepo);
        }

        [HttpGet("{carId}")]
        public ActionResult<Car> GetRental(Guid carId)
        {
            var carFromRepo = _carRentalRepository.GetCar(carId);

            if (carFromRepo == null)
            {
                return NotFound();
            }

            return (carFromRepo);
        }
    }
}
