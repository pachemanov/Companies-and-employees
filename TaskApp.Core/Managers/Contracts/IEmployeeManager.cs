using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.DTOs;

namespace TaskApp.Core.Managers.Contracts
{
    public interface IEmployeeManager
    {
        Task<EmployeeDto> Create(EmployeeDto employee);

        Task<EmployeeDto> Update(EmployeeDto employee);

        Task Delete(int employeeId);

        Task<EmployeeDto> Get(int id);

        Task<IEnumerable<EmployeeDto>> All();
        Task<IEnumerable<EmployeeDto>> All(int id);
    }
}
