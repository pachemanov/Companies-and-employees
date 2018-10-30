using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Core.DTOs;

namespace TaskApp.Core.Managers.Contracts
{
    public interface ICompanyManager
    {
        Task<CompanyDto> Create(CompanyDto company);

        Task<CompanyDto> Update(CompanyDto company);

        Task Delete(int companyId);
        Task<IEnumerable<CompanyDto>> Companies();
        Task<CompanyDto> Find(int id);
    }
}
