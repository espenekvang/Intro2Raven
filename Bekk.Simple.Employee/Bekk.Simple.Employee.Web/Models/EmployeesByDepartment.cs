using System.Collections.Generic;

namespace Bekk.Simple.Employee.Models
{
    internal class EmployeesByDepartment
    {
        public string Department { get; set; }
        public List<Employee> Employees { get; set; }
    }
}