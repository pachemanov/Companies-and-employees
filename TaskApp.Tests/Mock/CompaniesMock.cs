using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskApp.Core.DTOs;

namespace TaskApp.Tests.Mock
{
    public class CompaniesMock
    {
        private IEnumerable<CompanyDto> data;

        public CompaniesMock()
        {
            this.data = new List<CompanyDto>()
            {
                new CompanyDto
                {
                    CompanyId = 1,
                    CreationDate = DateTime.Now.AddMonths(-1),
                    Name = "Test 1"
                },
                new CompanyDto
                {
                    CompanyId = 2,
                    CreationDate = DateTime.Now.AddMonths(-2),
                    Name = "Test 2"
                },
                new CompanyDto
                {
                    CompanyId = 3,
                    CreationDate = DateTime.Now.AddMonths(-3),
                    Name = "Test 3"
                }
            };
        }


        public IEnumerable<CompanyDto> GetMockCompanies()
        {
            return this.data;
        }

        public CompanyDto GetMockEmptyCompany()
        {
            return new CompanyDto();
        }

        public CompanyDto GetNullInsteadCompany()
        {
            return null;
        }

        public CompanyDto Find(int id)
        {
            return this.data.FirstOrDefault(x => x.CompanyId == id);
        }

        public CompanyDto UpdateReturnNull()
        {
            return null;
        }

        public CompanyDto GetFirstCompany()
        {
            return this.data.FirstOrDefault();
        }

        public CompanyDto GetCompanyWithNameOnly()
        {
            return new CompanyDto
            {
                Name = "Test Company"
            };
        }
    }
}
