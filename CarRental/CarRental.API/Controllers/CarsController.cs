using AutoMapper;
using CarRental.API.Entities;
using CarRental.API.Models;
using CarRental.API.ResourceParameters;
using CarRental.API.Services;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper _mapper;

        public CarsController(ICarRentalRepository carRentalRepository, IMapper mapper)
        {
            _carRentalRepository = carRentalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<Car>> GetCars([FromQuery]CarsResourceParameters carsResourceParameters)
        {
            var carsFromRepo = _carRentalRepository.GetCars(carsResourceParameters);
            return Ok(carsFromRepo);
        }

        [HttpGet("{carId}", Name = "GetCar")]
        public ActionResult<Car> GetRental(Guid carId)
        {
            var carFromRepo = _carRentalRepository.GetCar(carId);

            if (carFromRepo == null)
            {
                return NotFound();
            }

            return (carFromRepo);
        }

        [HttpPost]
        public ActionResult<Car> CreateCar(CarForCreationDto car)
        {
            var carEntity = _mapper.Map<Car>(car);
            _carRentalRepository.AddCar(carEntity);
            _carRentalRepository.Save();

            return CreatedAtRoute("GetCar", new { carId = carEntity.Id }, carEntity);
        }

        [HttpPut("{carId}")]
        public IActionResult UpdateCar(Guid carId, CarForUpdateDto car)
        {
            var carFromRepo = _carRentalRepository.GetCar(carId);

            if (carFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(car, carFromRepo);

            _carRentalRepository.UpdateCar(carFromRepo);
            _carRentalRepository.Save();

            return NoContent();
        }

        [HttpPatch("{carId}")]
        public IActionResult UpdateCar(Guid carId, JsonPatchDocument<CarForUpdateDto> patchDocument)
        {
            var carFromRepo = _carRentalRepository.GetCar(carId);

            if (carFromRepo == null)
            {
                return NotFound();
            }

            var carToPatch = _mapper.Map<CarForUpdateDto>(carFromRepo);

            patchDocument.ApplyTo(carToPatch, ModelState);

            if (!TryValidateModel(carToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(carToPatch, carFromRepo);

            _carRentalRepository.UpdateCar(carFromRepo);
            _carRentalRepository.Save();

            return NoContent();
        }
    }
}
