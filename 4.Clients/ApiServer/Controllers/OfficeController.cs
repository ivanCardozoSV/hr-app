using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServer.Contracts.Office;
using AutoMapper;
using Core;
using Domain.Services.Contracts.Office;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OfficeController : BaseController<OfficeController> {

        IOfficeService _OfficeService;
        private IMapper _mapper;

        public OfficeController(IOfficeService OfficeService,
                                   ILog<OfficeController> logger,
                                   IMapper mapper): base(logger)
        {
            _OfficeService = OfficeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var Offices = _OfficeService.List();

                return Accepted(_mapper.Map<List<ReadedOfficeViewModel>>(Offices));
            });
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return ApiAction(() =>
            {
                var Office = _OfficeService.Read(Id);

                if (Office == null)
                {
                    return NotFound(Id);
                }

                return Accepted(_mapper.Map<ReadedOfficeViewModel>(Office));
            });
        }

        // POST api/skills
        // Creation
        [HttpPost]
        public IActionResult Post([FromBody] CreateOfficeViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateOfficeContract>(vm);
                var returnContract = _OfficeService.Create(contract);

                return Created("Get", _mapper.Map<CreatedOfficeViewModel>(returnContract));
            });
        }

        // PUT api/skills/5
        // Mutation
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody]UpdateOfficeViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateOfficeContract>(vm);
                contract.Id = Id;
                _OfficeService.Update(contract);

                return Accepted(new { Id });
            });
        }

        // DELETE api/skills/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return ApiAction(() =>
            {
                _OfficeService.Delete(Id);
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