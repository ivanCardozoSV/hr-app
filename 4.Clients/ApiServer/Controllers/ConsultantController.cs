using ApiServer.Contracts.Consultant;
using Domain.Services.Contracts.Consultant;
using AutoMapper;
using Core;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    public class ConsultantController : BaseController<ConsultantController>
    {
        readonly IConsultantService _consultantService;
        private readonly IMapper _mapper;

        public ConsultantController(IConsultantService consultantService, IMemCache cache, ILog<ConsultantController> logger, IMapper mapper) : base(logger)
        {
            _consultantService = consultantService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var consultants = _consultantService.List();

                return Accepted(_mapper.Map<List<ReadedConsultantViewModel>>(consultants));
            });
        }

        // GET api/consultant/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return ApiAction(() =>
            {
                var consultant = _consultantService.Read(id);

                if (consultant == null)
                {
                    return NotFound(id);
                }

                var vm = _mapper.Map<ReadedConsultantViewModel>(consultant);
                return Accepted(vm);
            });
        }

        // GET api/consultant/GetByName/jhon
        [HttpGet]
        [Route("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            return ApiAction(() =>
            {
                var consultants = _consultantService.GetConsultantsByName(name);

                return Accepted(consultants);
            });
        }

        [HttpGet("GetByEmail")]
        public IActionResult GetByEmail([FromQuery] string email)
        {
            return ApiAction(() =>
            {
                var consultant = _consultantService.GetByEmail(email);
                return Accepted(_mapper.Map<ReadedConsultantViewModel>(consultant));
            });
        }

        // POST api/consultant
        // Creation
        [HttpPost]
        public IActionResult Post([FromBody]CreateConsultantViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateConsultantContract>(vm);
                var returnContract = _consultantService.Create(contract);

                return Created("Get", _mapper.Map<CreatedConsultantViewModel>(returnContract));
            });
        }

        // PUT api/consultant/5
        // Mutation
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateConsultantViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateConsultantContract>(vm);
                contract.Id = id;
                _consultantService.Update(contract);

                return Accepted(new { id });
            });
        }

        // DELETE api/consultant/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _consultantService.Delete(id);
                return Accepted();
            });
        }
    }
}