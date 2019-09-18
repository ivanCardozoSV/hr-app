using ApiServer.Contracts.Employee;
using ApiServer.Contracts.EmployeeCasualty;
using AutoMapper;
using Core;
using Domain.Model;
using Domain.Services.Contracts.Employee;
using Domain.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<EmployeesController>
    {
        IEmployeeService _employeeService;
        private IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService,
                                 ILog<EmployeesController> logger,
                                 IMapper mapper) : base(logger)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return ApiAction(() =>
            {
                var employees = _employeeService.List();
                return Accepted(_mapper.Map<List<ReadedEmployeeViewModel>>(employees));
            });
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            return ApiAction(() =>
            {
                var employee = _employeeService.getById(id);
                return Accepted(_mapper.Map<ReadedEmployeeViewModel>(employee));
            });
        }

        [HttpGet("GetByDni")]
        public IActionResult GetByDNI([FromQuery] int dni)
        {
            return ApiAction(() =>
            {
                var employee = _employeeService.getByDNI(dni);
                return Accepted(_mapper.Map<ReadedEmployeeViewModel>(employee));
            });
        }

        [HttpGet("GetByEmail")]
        public IActionResult GetByEmail([FromQuery] string email)
        {
            return ApiAction(() =>
            {
                var employee = _employeeService.GetByEmail(email);
                return Accepted(_mapper.Map<ReadedEmployeeViewModel>(employee));
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return ApiAction(() =>
            {
                _employeeService.Delete(id);
                return Accepted();
            });
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody]UpdateEmployeeViewModel viewModel)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<UpdateEmployeeContract>(viewModel);
                _employeeService.UpdateEmployee(contract);

                return Accepted();
            });
        }

        [HttpPost]
        public IActionResult Add([FromBody]CreateEmployeeViewModel viewModel)
        {
            return ApiAction(() =>
            {
                var contract = _mapper.Map<CreateEmployeeContract>(viewModel);
                var returnContract = _employeeService.Create(contract);

                return Created("Get", _mapper.Map<CreatedEmployeeViewModel>(returnContract));
            });
        }
    }
}
