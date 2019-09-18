using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServer.Contracts.Room;
using AutoMapper;
using Core;
using Domain.Services.Contracts.Room;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoomController : BaseController<RoomController> {

        IRoomService _RoomService;
        private IMapper _mapper;

        public RoomController(IRoomService RoomService,
                                   ILog<RoomController> logger,
                                   IMapper mapper): base(logger)
        {
            _RoomService = RoomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var Rooms = _RoomService.List();

                return Accepted(_mapper.Map<List<ReadedRoomViewModel>>(Rooms));
            });
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return ApiAction(() =>
            {
                var Room = _RoomService.Read(Id);

                if (Room == null)
                {
                    return NotFound(Id);
                }

                return Accepted(_mapper.Map<ReadedRoomViewModel>(Room));
            });
        }

        // POST api/skills
        // Creation
        [HttpPost]
        public IActionResult Post([FromBody] CreateRoomViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateRoomContract>(vm);
                var returnContract = _RoomService.Create(contract);

                return Created("Get", _mapper.Map<CreatedRoomViewModel>(returnContract));
            });
        }

        // PUT api/skills/5
        // Mutation
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody]UpdateRoomViewModel vm)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateRoomContract>(vm);
                contract.Id = Id;
                _RoomService.Update(contract);

                return Accepted(new { Id });
            });
        }

        // DELETE api/skills/5
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            return ApiAction(() =>
            {
                _RoomService.Delete(Id);
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