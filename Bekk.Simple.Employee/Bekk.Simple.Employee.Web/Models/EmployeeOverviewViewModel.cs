using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Bekk.Simple.Employee.Models
{
    public class EmployeeOverviewViewModel
    {
        public IDictionary<string, List<Employee>> DepartmentsAndEmployees { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        public IEnumerable<SelectListItem> GetDepartmentSelectionList()
        {
            return Departments.Select(department => new SelectListItem {Text = department.Name, Value = department.Name}).ToList();
        }

        public IEnumerable<SelectListItem> GetEmployeeSelectionList()
        {
            var employees = new List<SelectListItem>();
            foreach (var departmentsAndEmployee in DepartmentsAndEmployees)
            {
                employees.AddRange(
                    departmentsAndEmployee.Value.Select(
                        employee => new SelectListItem {Text = employee.Name, Value = employee.Name}));
            }

            return employees;
        }
    }
}