using System;
using System.Collections.Generic;
using System.Text;

namespace TaskApp.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
