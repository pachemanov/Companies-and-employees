using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.DTOs;
using TaskApp.Core.Helpers.Contract;
using TaskApp.Core.Managers.Contracts;
using TaskApp.Models;

namespace TaskApp.Core.Managers
{
    public class EmployeeManager : BaseManager, IEmployeeManager
    {
        private IEmployeeHelper helper;

        public EmployeeManager(IMapper mapper, IEmployeeHelper helper)
            : base(mapper)
        {
            this.helper = helper;
        }

        public async Task<IEnumerable<EmployeeDto>> All()
        {
            var employees = await this.helper.All();

            return this.mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<IEnumerable<EmployeeDto>> All(int id)
        {
            var employees = await this.helper.All(id);

            return this.mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> Create(EmployeeDto employee)
        {
            if (!await this.helper.IsValidCompany(employee.CompanyId))
            {
                throw new Exception("Not valid company id");
            }

            var  mappedEmployee = this.mapper.Map<Employee>(employee);

            return this.mapper.Map<EmployeeDto>(await this.helper.Create(mappedEmployee));
        }

        public async Task Delete(int employeeId)
        {
            await this.helper.Delete(employeeId);
        }

        public async Task<EmployeeDto> Get(int id)
        {
            return this.mapper.Map<EmployeeDto>(await this.helper.Find(id));
        }

        public async Task<EmployeeDto> Update(EmployeeDto employee)
        {
            if (!await this.helper.IsValidCompany(employee.CompanyId))
            {
                throw new Exception("Not valid company id");
            }

            var mappedEmployee = this.mapper.Map<Employee>(employee);

            return this.mapper.Map<EmployeeDto>(await this.helper.Update(mappedEmployee));
        }
    }
}
