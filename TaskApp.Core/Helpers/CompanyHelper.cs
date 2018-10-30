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
    public class CompanyHelper : BaseHelper, ICompanyHelper
    {
        public CompanyHelper(IUnitOfWork db) 
            : base(db)
        {
        }

        public async Task<Company> Create(Company company)
        {
            await db.CompanyRepository.Insert(company);

            return company;
        }

        public async Task Delete(int companyId)
        {
            await db.CompanyRepository.Delete(companyId);
        }

        public async Task<Company> Find(int id)
        {
            return await db.CompanyRepository.GetByID(id);
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await this.db.CompanyRepository.Get();
        }

        public async Task<Company> Update(Company company)
        {
            await db.CompanyRepository.Update(company);

            return company;
        }
    }
}
