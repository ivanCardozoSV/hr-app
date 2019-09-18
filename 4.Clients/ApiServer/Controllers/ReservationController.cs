using System.Collections.Generic;
using ApiServer.Contracts.Reservation;
using AutoMapper;
using Core;
using Domain.Services.Contracts.Reservation;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : BaseController<ReservationController>
    {
        IReservationService _ReservationService;
        private IMapper _mapper;

        public ReservationController(IReservationService ReservationService, ILog<ReservationController> logger, IMapper mapper) : base(logger)
        {
            _ReservationService = ReservationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var communities = _ReservationService.List();

                return Accepted(_mapper.Map<List<ReadedReservationViewModel>>(communities));
            });
        }

        // GET api/Reservations/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return ApiAction(() =>
            {
                var Reservation = _ReservationService.Read(id);

                if (Reservation == null)
                {
                    return NotFound(id);
                }

                return Accepted(_mapper.Map<ReadedReservationViewModel>(Reservation));
            });
        }

        // POST api/Reservations
        // Creation
        [HttpPost]
        public IActionResult Post([FromBody]CreateReservationViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateReservationContract>(vm);
                var returnContract = _ReservationService.Create(contract);

                return Created("Get", _mapper.Map<CreatedReservationViewModel>(returnContract));
            });
        }

        // PUT api/Reservations/5
        // Mutation
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateReservationViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateReservationContract>(vm);
                contract.Id = id;
                _ReservationService.Update(contract);

                return Accepted();
            });
        }

        // DELETE api/Reservations/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _ReservationService.Delete(id);
                return Accepted();
            });
        }

        [HttpGet("Ping")]
        public IActionResult Ping()
        {
            return Ok(new { Status = "OK" });
        }
    }
}