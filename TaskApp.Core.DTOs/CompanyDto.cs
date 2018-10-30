using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskApp.Core.DTOs
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }

        [Required (AllowEmptyStrings = false)]
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<EmployeeDto> Employees { get; set; }
    }
}
