using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bekk.Simple.Employee.Extensions;
using Bekk.Simple.Employee.Models;

namespace Bekk.Simple.Employee.Controllers
{
    public class EmployeeOverviewController : Controller
    {
        private static readonly List<Models.Employee> Employees = new List<Models.Employee>
        {
            new Models.Employee {Name = "Donald Duck", Email = "donald@duck.com", Department = new Department{Name = "Tech"}},
            new Models.Employee {Name = "Dolly Duck", Email = "dolly@duck.com", Department = new Department{Name ="BMC"}}
        };
        
        private static readonly List<Department> Departments = new List<Department>
        {
            new Department{Name = "Tech"},
            new Department{Name= "Interactive"},
            new Department{Name = "BMC"}
        };
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(CreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(NewEmployeeViewModel newEmployee)
        {
            Employees.Add(newEmployee.ToEmployee(Departments));
            return View("Index", CreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(NewEmployeeViewModel deleteEmployee)
        {
            Employees.RemoveAll(employee => employee.Name.Equals(deleteEmployee.Name));

            return View("Index", CreateViewModel());
        }

        private static EmployeeOverviewViewModel CreateViewModel()
        {
            IDictionary<string, List<Models.Employee>> departmentsAndEmployees =
                Employees.GroupBy(employee => employee.Department.Name)
                    .ToDictionary(grouping => grouping.Key, grouping => grouping.ToList());

            var viewModel = new EmployeeOverviewViewModel { DepartmentsAndEmployees = departmentsAndEmployees, Departments = Departments };
            return viewModel;
        }
    }
}
