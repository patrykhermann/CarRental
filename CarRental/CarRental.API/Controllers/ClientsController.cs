using AutoMapper;
using CarRental.API.Models;
using CarRental.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly ICarRentalRepository _carRentalRepository;
        private readonly IMapper _mapper;

        public ClientsController(ICarRentalRepository carRentalRepository, IMapper mapper)
        {
            _carRentalRepository = carRentalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientDto>> GetClients()
        {
            var clientsFromRepo = _carRentalRepository.GetClients();
            return Ok(_mapper.Map<IEnumerable<ClientDto>>(clientsFromRepo));
        }

        [HttpGet("{clientId}")]
        public ActionResult<ClientDto> GetClient(Guid clientId)
        {
            var clientFromRepo = _carRentalRepository.GetClient(clientId);

            if(clientFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientDto>(clientFromRepo));
        }
    }
}
