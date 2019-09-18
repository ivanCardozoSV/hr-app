using ApiServer.Contracts.Stage;
using AutoMapper;
using Core;
using Domain.Services.Contracts.Stage;
using Domain.Services.Contracts.Stage.StageItem;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    public class ProcessStageController : BaseController<ProcessStageController>
    {
        IProcessStageService _processStageService;
        private IMapper _mapper;

        public ProcessStageController(IProcessStageService processStageService,
            ILog<ProcessStageController> logger, IMapper mapper)
            : base(logger)
        {
            _processStageService = processStageService;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var stages = _processStageService.List();

                return Accepted(_mapper.Map<List<ReadedStageViewModel>>(stages));
            });
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        //[Authorize(Policy = SecurityClaims.CAN_LIST_CANDIDATE)]
        public IActionResult Get(int id)
        {
            return ApiAction(() =>
            {
                var stage = _processStageService.Read(id);

                return Accepted(_mapper.Map<ReadedStageViewModel>(stage));
            });
        }

        // POST api/<controller>
        //creation
        [HttpPost]
        public IActionResult Post([FromBody]CreateStageViewModel createStageViewModel)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateStageContract>(createStageViewModel);
                var returnContract = _processStageService.Create(contract);

                return Created("Get", _mapper.Map<CreatedStageViewModel>(returnContract));
            });
        }

        // PUT api/dummies/5
        // Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateStageViewModel updateStageViewModel)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateStageContract>(updateStageViewModel);
                contract.Id = id;

                _processStageService.Update(contract);

                return Accepted();
            });
        }

        // DELETE api/dummies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _processStageService.Delete(id);

                return Accepted();
            });
        }


    }
}
