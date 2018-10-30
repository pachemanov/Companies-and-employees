using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.DTOs;
using TaskApp.Core.Helpers.Contract;
using TaskApp.DAL.UnitOfWork.Contracts;
using TaskApp.Models;

namespace TaskApp.Core.Helpers
{
    public class EmployeeHelper : BaseHelper, IEmployeeHelper
    {
        public EmployeeHelper(IUnitOfWork db) 
            : base(db)
        {
        }

        public async Task<IEnumerable<Employee>> All()
        {
            return await this.db.EmployeeRepository.Get();
        }

        public async Task<IEnumerable<Employee>> All(int id)
        {
            return await this.db.EmployeeRepository.Get(x => x.CompanyId == id);
        }

        public async Task<Employee> Find(int id)
        {
            return await this.db.EmployeeRepository.GetByID(id);
        }

        public async Task<Employee> Create(Employee employee)
        {
            await db.EmployeeRepository.Insert(employee);

            return employee;
        }

        public async Task Delete(int employeeId)
        {
            await db.EmployeeRepository.Delete(employeeId);
        }

        public async Task<Employee> Update(Employee employee)
        {
            await db.EmployeeRepository.Update(employee);

            return employee;
        }

        public async Task<bool> IsValidCompany(int companyId)
        {
            return await this.db.CompanyRepository.Exist(x => x.CompanyId == companyId);
        }
    }
}
