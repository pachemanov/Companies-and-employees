using System;
using System.Collections.Generic;
using System.Text;
using TaskApp.DAL;
using AutoMapper;
using TaskApp.Core.DTOs;
using TaskApp.Core.Managers.Contracts;
using System.Threading.Tasks;
using TaskApp.Core.Helpers.Contract;
using TaskApp.Models;

namespace TaskApp.Core.Managers
{
    public class CompanyManager : BaseManager, ICompanyManager
    {
        private ICompanyHelper helper;

        public CompanyManager(IMapper mapper, ICompanyHelper helper) 
            : base(mapper)
        {
            this.helper = helper;
        }

        public async Task<IEnumerable<CompanyDto>> Companies()
        {
            var companies = await this.helper.GetCompanies();

            return this.mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public async Task<CompanyDto> Create(CompanyDto company)
        {
            var mappedCompany = this.mapper.Map<Company>(company);

            var newCompany = await this.helper.Create(mappedCompany);

            return this.mapper.Map<CompanyDto>(newCompany);
        }

        public async Task Delete(int companyId)
        {
            await this.helper.Delete(companyId);
        }

        public async Task<CompanyDto> Find(int id)
        {
            var company = await this.helper.Find(id);

            return this.mapper.Map<CompanyDto>(company);
        }

        public async Task<CompanyDto> Update(CompanyDto company)
        {
            var mappedCompany = this.mapper.Map<Company>(company);

            await this.helper.Update(mappedCompany);

            return company;
        }
    }
}
