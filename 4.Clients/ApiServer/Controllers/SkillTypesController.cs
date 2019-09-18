using System.Collections.Generic;
using ApiServer.Contracts.SkillType;
using AutoMapper;
using Core;
using Domain.Services.Contracts.SkillType;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillTypesController : BaseController<SkillTypesController>
    {
        ISkillTypeService _skillTypeService;
        private IMapper _mapper;

        public SkillTypesController(ISkillTypeService skillTypeService, ILog<SkillTypesController> logger, IMapper mapper) : base(logger)
        {
            _skillTypeService = skillTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var skillsTypes = _skillTypeService.List();

                return Accepted(_mapper.Map<List<ReadedSkillTypeViewModel>>(skillsTypes));
            });
        }

        // GET api/skillTypes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return ApiAction(() =>
            {
                var skillTpe = _skillTypeService.Read(id);

                if (skillTpe == null)
                {
                    return NotFound(id);
                }

                return Accepted(_mapper.Map<ReadedSkillTypeViewModel>(skillTpe));
            });
        }

        // POST api/skillTypes
        // Creation
        [HttpPost]
        public IActionResult Post([FromBody]CreateSkillTypeViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateSkillTypeContract>(vm);
                var returnContract = _skillTypeService.Create(contract);

                return Created("Get", _mapper.Map<CreatedSkillTypeViewModel>(returnContract));
            });
        }

        // PUT api/skillTypes/5
        // Mutation
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateSkillTypeViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateSkillTypeContract>(vm);
                contract.Id = id;
                _skillTypeService.Update(contract);

                return Accepted(new { id });
            });
        }

        // DELETE api/skillTypes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _skillTypeService.Delete(id);
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