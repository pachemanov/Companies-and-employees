using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.DTOs;
using TaskApp.Models;

namespace TaskApp.Core.Helpers.Contract
{
    public interface ICompanyHelper
    {
        Task<Company> Create(Company company);

        Task<Company> Update(Company company);

        Task Delete(int companyId);
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> Find(int id);
    }
}
