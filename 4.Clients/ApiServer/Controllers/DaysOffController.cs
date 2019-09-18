using ApiServer.Contracts.DaysOff;
using AutoMapper;
using Core;
using Domain.Services.Contracts.DaysOff;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysOffController : BaseController<DaysOffController>
    {
        IDaysOffService _daysOffervice;
        private IMapper _mapper;

        public DaysOffController(IDaysOffService daysOffervice, ILog<DaysOffController> logger, IMapper mapper) : base(logger)
        {
            _daysOffervice = daysOffervice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var daysOff = _daysOffervice.List();

                return Accepted(_mapper.Map<List<ReadedDaysOffViewModel>>(daysOff));
            });
        }

        //GET api/daysOff/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return ApiAction(() =>
            {
                var daysOff = _daysOffervice.Read(id);

                if (daysOff == null)
                {
                    return NotFound(id);
                }

                return Accepted(_mapper.Map<ReadedDaysOffViewModel>(daysOff));
            });
        }

        //GET api/daysOff/dni
        [HttpGet("GetByDni")]
        public IActionResult GetByDni([FromQuery]int dni)
        {
            return ApiAction(() =>
            {
                var daysOff = _daysOffervice.ReadByDni(dni);

                if (daysOff == null)
                {
                    return NotFound(dni);
                }

                return Accepted(_mapper.Map<List<ReadedDaysOffViewModel>>(daysOff));
            });
        }

        //POST api/daysOff
        //Creation
        [HttpPost]
        public IActionResult Post([FromBody]CreateDaysOffViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateDaysOffContract>(vm);
                var returnContract = _daysOffervice.Create(contract);

                return Created("Get", _mapper.Map<CreatedDaysOffViewModel>(returnContract));
            });
        }

        //PUT api/daysOff/5
        // Mutation
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateDaysOffViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateDaysOffContract>(vm);
                contract.Id = id;
                _daysOffervice.Update(contract);

                return Accepted(new { id });
            });
        }

        //DELETE api/daysOff/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _daysOffervice.Delete(id);
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