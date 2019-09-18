using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServer.Contracts.Skills;
using AutoMapper;
using Core;
using Domain.Services.Contracts.Skill;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : BaseController<SkillsController>
    {
        ISkillService _skillService;
        private IMapper _mapper;

        public SkillsController(ISkillService skillService, ILog<SkillsController> logger, IMapper mapper): base(logger)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var skills = _skillService.List();

                return Accepted(_mapper.Map<List<ReadedSkillViewModel>>(skills));
            });
        }

        // GET api/skills/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return ApiAction(() =>
            {
                var skill = _skillService.Read(id);

                if (skill == null)
                {
                    return NotFound(id);
                }

                return Accepted(_mapper.Map<ReadedSkillViewModel>(skill));
            });
        }

        // POST api/skills
        // Creation
        [HttpPost]
        public IActionResult Post([FromBody] CreateSkillViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateSkillContract>(vm);
                var returnContract = _skillService.Create(contract);

                return Created("Get", _mapper.Map<CreatedSkillViewModel>(returnContract));
            });
        }

        // PUT api/skills/5
        // Mutation
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateSkillViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateSkillContract>(vm);
                contract.Id = id;
                _skillService.Update(contract);

                return Accepted(new { id });
            });
        }

        // DELETE api/skills/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _skillService.Delete(id);
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