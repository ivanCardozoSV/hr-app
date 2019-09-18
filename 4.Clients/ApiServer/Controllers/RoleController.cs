using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServer.Contracts.Role;
using AutoMapper;
using Core;
using Domain.Services.Contracts.Role;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : BaseController<RoleController>
    {
        IRoleService _roleService;
        private IMapper _mapper;

        public RoleController(IRoleService roleService,
                         ILog<RoleController> logger,
                         IMapper mapper) : base(logger)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ApiAction(() =>
            {
                var roles = _roleService.List();

                return Accepted(_mapper.Map<List<ReadedRoleViewModel>>(roles));
            });
        }

        [HttpPost]
        public IActionResult Add([FromBody]CreateRoleViewModel viewModel)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateRoleContract>(viewModel);
                var returnContract = _roleService.Create(contract);

                return Created("Get", _mapper.Map<CreatedRoleViewModel>(returnContract));
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _roleService.Delete(id);
                return Accepted();
            });
        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody]UpdateRoleViewModel viewModel)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateRoleContract>(viewModel);
                contract.Id = Id;
                _roleService.Update(contract);

                return Accepted(new { Id });
            });
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return ApiAction(() =>
            {
                var role = _roleService.Read(Id);

                if (role == null)
                {
                    return NotFound(Id);
                }

                return Accepted(_mapper.Map<ReadedRoleViewModel>(role));
            });
        }
    }
}