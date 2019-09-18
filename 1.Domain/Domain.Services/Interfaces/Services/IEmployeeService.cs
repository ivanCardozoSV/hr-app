using Domain.Model;
using Domain.Services.Contracts.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces.Services
{
    public interface IEmployeeService
    {
        IEnumerable<ReadedEmployeeContract> List();
        void Delete(int id);
        CreatedEmployeeContract Create(CreateEmployeeContract contract);
        void UpdateEmployee(UpdateEmployeeContract contract);
        Employee getById(int id);

        Employee getByDNI(int dni);
        Employee GetByEmail(string email);
    }
}
