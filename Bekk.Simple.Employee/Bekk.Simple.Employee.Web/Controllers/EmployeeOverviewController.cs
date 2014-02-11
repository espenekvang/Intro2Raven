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
            Employees.Add(newEmployee.ToEmployee());
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(NewEmployeeViewModel deleteEmployee)
        {
            Employees.RemoveAll(employee => employee.Name.Equals(deleteEmployee.Name));
            return RedirectToAction("Index");
        }

        private static EmployeeOverviewViewModel CreateViewModel()
        {
            IDictionary<string, List<Models.Employee>> departmentsAndEmployees = new Dictionary<string, List<Models.Employee>>();

            foreach (var department in Departments)
            {
                var employeesInDepartment = Employees.Where(employee => employee.Department.Name == department.Name).ToList();

                if(employeesInDepartment.Any())
                    departmentsAndEmployees.Add(department.Name, employeesInDepartment);    
            }
                
            var viewModel = new EmployeeOverviewViewModel { DepartmentsAndEmployees = departmentsAndEmployees, Departments = Departments };
            return viewModel;
        }
    }
}
