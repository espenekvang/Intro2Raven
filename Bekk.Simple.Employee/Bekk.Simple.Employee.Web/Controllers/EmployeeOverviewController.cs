using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bekk.Simple.Employee.Extensions;
using Bekk.Simple.Employee.Models;

namespace Bekk.Simple.Employee.Controllers
{
    public class EmployeeOverviewController : RavenController
    {
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
            RavenSession.Store(newEmployee.ToEmployee());
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DeleteEmployeeViewModel deleteEmployee)
        {
            RavenSession.Advanced.DocumentStore.DatabaseCommands.Delete(string.Format("employees/{0}", deleteEmployee.Id), null);
            return RedirectToAction("Index");
        }

        private EmployeeOverviewViewModel CreateViewModel()
        {

            var allEmployees = RavenSession.Query<Models.Employee>().ToList();
            IDictionary<string, List<Models.Employee>> departmentsAndEmployees = new Dictionary<string, List<Models.Employee>>();

            foreach (var department in Departments)
            {
                var employeesInDepartment = allEmployees.Where(employee => employee.Department.Name == department.Name).ToList();
                if(employeesInDepartment.Any())
                    departmentsAndEmployees.Add(department.Name, employeesInDepartment);    
            }
                
            var viewModel = new EmployeeOverviewViewModel { DepartmentsAndEmployees = departmentsAndEmployees, Departments = Departments };
            return viewModel;
        }
    }
}
