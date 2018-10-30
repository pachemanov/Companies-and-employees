using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApp.Core.DTOs;
using TaskApp.Core.Managers.Contracts;
using TaskApp.DAL;
using TaskApp.Models;

namespace TaskApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager manager;

        public EmployeesController(
            IEmployeeManager manager)
        {
            this.manager = manager;
        }

        // GET: api/Employees/Company/5
        [HttpGet]
        [Route("Company/{id}")]
        public async Task<IEnumerable<EmployeeDto>> GetEmployees([FromRoute] int id)
        {
            return await this.manager.All(id);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be positive number.");
            }

            EmployeeDto employee = await this.manager.Get(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] EmployeeDto employee)
        {
            if (string.IsNullOrEmpty(employee.FirstName) ||
                string.IsNullOrEmpty(employee.Lastname))
            {
                return BadRequest("Names are required.");
            }

            if (employee.CompanyId < 1)
            {
                return BadRequest("CompanyId must be positive number.");
            }

            if (employee.Salary < 1)
            {
                return BadRequest("Salary is required.");
            }

            if (employee.VacationDays < 1)
            {
                return BadRequest("Vacation days are required.");
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest("Ids should be equal.");
            }

            try
            {
                await this.manager.Update(employee);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeDto employee)
        {
            if (string.IsNullOrEmpty(employee.FirstName) ||
                string.IsNullOrEmpty(employee.Lastname))
            {
                return BadRequest("Names are required.");
            }

            if (employee.CompanyId < 1)
            {
                return BadRequest("CompanyId must be positive number.");
            }

            if (employee.Salary < 1)
            {
                return BadRequest("Salary is required.");
            }

            if (employee.VacationDays < 1)
            {
                return BadRequest("Vacation days are required.");
            }

            try
            {
                await this.manager.Create(employee);
            }
            catch (Exception)
            {
                return NotFound();
            }


            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be positive number.");
            }

            try
            {
                await this.manager.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}