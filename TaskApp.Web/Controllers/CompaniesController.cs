using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyManager manager;

        public CompaniesController(ICompanyManager manager)
        {
            this.manager = manager;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<IEnumerable<CompanyDto>> GetCompanies()
        {
            return await this.manager.Companies();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany([FromRoute] int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be positive number.");
            }

            try
            {
                var company = await this.manager.Find(id);

                if (company == null)
                {
                    return NotFound();
                }

                return Ok(company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany([FromRoute] int id, [FromBody] CompanyDto company)
        {
            if (id < 1)
            {
                return BadRequest("Id must be positive number.");
            }

            if (company == null)
            {
                return BadRequest("No company provided.");
            }

            if (string.IsNullOrEmpty(company.Name))
            {
                return BadRequest("Company name is required.");
            }

            if (id != company.CompanyId)
            {
                return BadRequest();
            }

            try
            {
                await this.manager.Update(company);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            

            return NoContent();
        }

        // POST: api/Companies
        [HttpPost()]
        public async Task<IActionResult> PostCompany([FromBody] CompanyDto company)
        {
            if (string.IsNullOrWhiteSpace(company.Name))
            {
                return BadRequest("Empty company name");
            }

            company.CreationDate = DateTime.Now;

            try
            {
               await this.manager.Create(company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] int id)
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