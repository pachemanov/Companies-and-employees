using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskApp.Core.DTOs;
using TaskApp.Models.Enum;

namespace TaskApp.Tests.Mock
{
    internal class EmployeesMock
    {
        private IEnumerable<EmployeeDto> data;

        internal EmployeesMock()
        {
            this.data = new List<EmployeeDto>
            {
                new EmployeeDto
                {
                    FirstName = "Ivan",
                    Lastname = "Ivanov",
                    CompanyId = 1,
                    EmployeeId = 1,
                    ExperienceLevel = ExperienceLevel.A,
                    Salary = 1000,
                    StartingDate = DateTime.Now.AddMonths(1),
                    VacationDays = 25
                },
                new EmployeeDto
                {
                    FirstName = "Georgi",
                    Lastname = "Georgiev",
                    CompanyId = 2,
                    EmployeeId = 2,
                    ExperienceLevel = ExperienceLevel.B,
                    Salary = 2000,
                    StartingDate = DateTime.Now.AddMonths(2),
                    VacationDays = 25
                },
                new EmployeeDto
                {
                    FirstName = "Dimitar",
                    Lastname = "Dimitrov",
                    CompanyId = 3,
                    EmployeeId = 3,
                    ExperienceLevel = ExperienceLevel.C,
                    Salary = 3000,
                    StartingDate = DateTime.Now.AddMonths(2),
                    VacationDays = 25
                }
            };
        }

        internal EmployeeDto GetEmployee(int id)
        {
            return this.data.FirstOrDefault(x => x.EmployeeId == id);
        }


        internal EmployeeDto GetEmployeeWithFakeId()
        {
            return new EmployeeDto
            {
                FirstName = "Ivan",
                Lastname = "Ivanov",
                CompanyId = 1,
                EmployeeId = -1,
                ExperienceLevel = ExperienceLevel.A,
                Salary = 1000,
                StartingDate = DateTime.Now.AddMonths(1),
                VacationDays = 25
            };
        }

        internal IEnumerable<EmployeeDto> GetAllEmployees(int id)
        {
            return this.data.Where(x => x.CompanyId == id).ToList();
        }

        internal EmployeeDto GetFirstEmployee()
        {
            return this.data.FirstOrDefault();
        }

        internal EmployeeDto GetNull()
        {
            return null;
        }

        internal EmployeeDto GetEmptyEmployee()
        {
            return new EmployeeDto();
        }

        internal IEnumerable<EmployeeDto> GetAllEmployees()
        {
            return this.data;
        }
           
    }
}
