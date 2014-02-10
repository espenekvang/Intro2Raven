using System.Collections.Generic;
using System.Linq;
using Bekk.Simple.Employee.Models;

namespace Bekk.Simple.Employee.Extensions
{
    public static class NewEmployeeViewModelExtension
    {
        public static Models.Employee ToEmployee(this NewEmployeeViewModel viewModel, List<Department> departments)
        {
            return new Models.Employee
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Department = departments.FirstOrDefault(department => department.Name.Equals(viewModel.Department))
            };
        }
    }
}