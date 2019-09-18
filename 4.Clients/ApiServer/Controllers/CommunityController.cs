using System.Collections.Generic;
using ApiServer.Contracts.Community;
using AutoMapper;
using Core;
using Domain.Services.Contracts.Community;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : BaseController<CommunityController>
    {
        ICommunityService _CommunityService;
        private IMapper _mapper;

        public CommunityController(ICommunityService CommunityService, ILog<CommunityController> logger, IMapper mapper) : base(logger)
        {
            _CommunityService = CommunityService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var communities = _CommunityService.List();

                return Accepted(_mapper.Map<List<ReadedCommunityViewModel>>(communities));
            });
        }

        // GET api/Communitys/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return ApiAction(() =>
            {
                var community = _CommunityService.Read(id);

                if (community == null)
                {
                    return NotFound(id);
                }

                return Accepted(_mapper.Map<ReadedCommunityViewModel>(community));
            });
        }

        // POST api/Communitys
        // Creation
        [HttpPost]
        public IActionResult Post([FromBody]CreateCommunityViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateCommunityContract>(vm);
                var returnContract = _CommunityService.Create(contract);

                return Created("Get", _mapper.Map<CreatedCommunityViewModel>(returnContract));
            });
        }

        // PUT api/Communitys/5
        // Mutation
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateCommunityViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateCommunityContract>(vm);
                contract.Id = id;
                _CommunityService.Update(contract);

                return Accepted(new { id });
            });
        }

        // DELETE api/Communitys/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _CommunityService.Delete(id);
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