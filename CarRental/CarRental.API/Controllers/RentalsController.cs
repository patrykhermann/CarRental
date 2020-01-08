using AutoMapper;
using CarRental.API.Models;
using CarRental.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("api/rentals")]
    public class RentalsController : ControllerBase
    {
        private readonly ICarRentalRepository _carRentalRepository;
        private readonly IMapper _mapper;

        public RentalsController(ICarRentalRepository carRentalRepository, IMapper mapper)
        {
            _carRentalRepository = carRentalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RentalDto>> GetRentals()
        {
            var rentalsFromRepo = _carRentalRepository.GetRentals();
            return Ok(_mapper.Map<IEnumerable<RentalDto>>(rentalsFromRepo));
        }

        [HttpGet("{rentalId}")]
        public ActionResult<RentalDto> GetRental(Guid rentalId)
        {
            var rentalFromRepo = _carRentalRepository.GetRental(rentalId);

            if(rentalFromRepo == null)
            {
                return NotFound();
            }

            return (_mapper.Map<RentalDto>(rentalFromRepo));
        }
    }
}
