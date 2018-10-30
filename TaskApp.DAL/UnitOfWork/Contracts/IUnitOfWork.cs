using System;
using System.Collections.Generic;
using System.Text;
using TaskApp.DAL.Repository;
using TaskApp.Models;

namespace TaskApp.DAL.UnitOfWork.Contracts
{
    public interface IUnitOfWork
    {
        GenericRepository<Company> CompanyRepository { get; }

        GenericRepository<Employee> EmployeeRepository { get; }

        void Save();

        void Dispose();
    }
}
