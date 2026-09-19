using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class DashboardViewModel
    {
        public int TotalEmployee { get; set; }
        public int TotalDepartments { get; set; }
        public int ActiveEmployees { get; set; }
        public int InactiveEmployees { get; set; }
        public decimal TotalSalary { get; set; }
        
        public List<Employee> Employees { get; set; }

    }
}