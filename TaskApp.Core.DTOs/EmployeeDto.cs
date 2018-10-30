using System;
using System.Collections.Generic;
using System.Text;
using TaskApp.Models.Enum;

namespace TaskApp.Core.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public ExperienceLevel ExperienceLevel { get; set; }

        public DateTime StartingDate { get; set; }

        public Decimal Salary { get; set; }

        public int VacationDays { get; set; }

        public int CompanyId { get; set; }
    }
}
