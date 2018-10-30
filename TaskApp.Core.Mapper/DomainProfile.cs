using AutoMapper;
using TaskApp.Core.DTOs;
using TaskApp.Models;

namespace TaskApp.Core.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyDto, Company>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
