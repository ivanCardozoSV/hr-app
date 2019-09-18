using ApiServer.Contracts.EmployeeCasualty;
using AutoMapper;
using Core;
using Domain.Services.Contracts.EmployeeCasualty;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCasualtyController : BaseController<EmployeeCasualtyController>
    {
        IEmployeeCasualtyService _employeeCasualtyervice;
        private IMapper _mapper;

        public EmployeeCasualtyController(IEmployeeCasualtyService employeeCasualtyervice, ILog<EmployeeCasualtyController> logger, IMapper mapper) : base(logger)
        {
            _employeeCasualtyervice = employeeCasualtyervice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var employeeCasualty = _employeeCasualtyervice.List();

                return Accepted(_mapper.Map<List<ReadedEmployeeCasualtyViewModel>>(employeeCasualty));
            });
        }

        //GET api/employeeCasualty/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return ApiAction(() =>
            {
                var employeeCasualty = _employeeCasualtyervice.Read(id);

                if (employeeCasualty == null)
                {
                    return NotFound(id);
                }

                return Accepted(_mapper.Map<ReadedEmployeeCasualtyViewModel>(employeeCasualty));
            });
        }

        //POST api/employeeCasualty
        //Creation
       [HttpPost]
        public IActionResult Post([FromBody]CreateEmployeeCasualtyViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateEmployeeCasualtyContract>(vm);
                var returnContract = _employeeCasualtyervice.Create(contract);

                return Created("Get", _mapper.Map<CreatedEmployeeCasualtyViewModel>(returnContract));
            });
        }

        //PUT api/employeeCasualty/5
        // Mutation
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateEmployeeCasualtyViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateEmployeeCasualtyContract>(vm);
                contract.Id = id;
                _employeeCasualtyervice.Update(contract);

                return Accepted(new { id });
            });
        }

        //DELETE api/employeeCasualty/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _employeeCasualtyervice.Delete(id);
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