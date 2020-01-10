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
        [HttpHead]
        public ActionResult<IEnumerable<ClientDto>> GetClients([FromQuery] ClientsResourceParameters clientsResourceParameters)
        {
            var clientsFromRepo = _carRentalRepository.GetClients(clientsResourceParameters);
            return Ok(_mapper.Map<IEnumerable<ClientDto>>(clientsFromRepo));
        }

        [HttpGet("{clientId}", Name = "GetClient")]
        public ActionResult<ClientDto> GetClient(Guid clientId)
        {
            var clientFromRepo = _carRentalRepository.GetClient(clientId);

            if(clientFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientDto>(clientFromRepo));
        }

        [HttpPost]
        public ActionResult<ClientDto> CreateClient(ClientForCreationDto client)
        {
            var clientEntity = _mapper.Map<Client>(client);
            _carRentalRepository.AddClient(clientEntity);
            _carRentalRepository.Save();

            var clientToReturn = _mapper.Map<ClientDto>(clientEntity);

            return CreatedAtRoute("GetClient", new { clientId = clientToReturn.Id }, clientToReturn);
        }

        [HttpPut("{clientId}")]
        public IActionResult Updateclient(Guid clientId, ClientForUpdateDto client)
        {
            var clientFromRepo = _carRentalRepository.GetClient(clientId);

            if (clientFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(client, clientFromRepo);

            _carRentalRepository.UpdateClient(clientFromRepo);
            _carRentalRepository.Save();

            return NoContent();
        }

        [HttpPatch("{clientId}")]
        public IActionResult Updateclient(Guid clientId, JsonPatchDocument<ClientForUpdateDto> patchDocument)
        {
            var clientFromRepo = _carRentalRepository.GetClient(clientId);

            if (clientFromRepo == null)
            {
                return NotFound();
            }

            var clientToPatch = _mapper.Map<ClientForUpdateDto>(clientFromRepo);

            patchDocument.ApplyTo(clientToPatch, ModelState);

            if (!TryValidateModel(clientToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(clientToPatch, clientFromRepo);

            _carRentalRepository.UpdateClient(clientFromRepo);
            _carRentalRepository.Save();

            return NoContent();
        }
    }
}
