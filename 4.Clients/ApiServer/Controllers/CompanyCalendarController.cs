using ApiServer.Contracts.CompanyCalendar;
using AutoMapper;
using Core;
using Domain.Services.Contracts.CompanyCalendar;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyCalendarController : BaseController<CompanyCalendarController>
    {
        ICompanyCalendarService _companyCalendarervice;
        private IMapper _mapper;

        public CompanyCalendarController(ICompanyCalendarService companyCalendarervice, ILog<CompanyCalendarController> logger, IMapper mapper) : base(logger)
        {
            _companyCalendarervice = companyCalendarervice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var companyCalendar = _companyCalendarervice.List();

                return Accepted(_mapper.Map<List<ReadedCompanyCalendarViewModel>>(companyCalendar));
            });
        }

        //GET api/companyCalendar/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return ApiAction(() =>
            {
                var companyCalendar = _companyCalendarervice.Read(id);

                if (companyCalendar == null)
                {
                    return NotFound(id);
                }

                return Accepted(_mapper.Map<ReadedCompanyCalendarViewModel>(companyCalendar));
            });
        }

        //POST api/companyCalendar
        //Creation
        [HttpPost]
        public IActionResult Post([FromBody]CreateCompanyCalendarViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateCompanyCalendarContract>(vm);
                var returnContract = _companyCalendarervice.Create(contract);

                return Created("Get", _mapper.Map<CreatedCompanyCalendarViewModel>(returnContract));
            });
        }

        //PUT api/companyCalendar/5
        // Mutation
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateCompanyCalendarViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateCompanyCalendarContract>(vm);
                contract.Id = id;
                _companyCalendarervice.Update(contract);

                return Accepted(new { id });
            });
        }

        //DELETE api/companyCalendar/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _companyCalendarervice.Delete(id);
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