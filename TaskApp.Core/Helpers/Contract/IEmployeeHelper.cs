using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.DTOs;
using TaskApp.Models;

namespace TaskApp.Core.Helpers.Contract
{
    public interface IEmployeeHelper
    {
        Task<Employee> Create(Employee employee);

        Task<Employee> Update(Employee employee);

        Task Delete(int employeeId);
        Task<IEnumerable<Employee>> All();

        Task<Employee> Find(int id);
        Task<IEnumerable<Employee>> All(int id);
        Task<bool> IsValidCompany(int companyId);
    }
}
