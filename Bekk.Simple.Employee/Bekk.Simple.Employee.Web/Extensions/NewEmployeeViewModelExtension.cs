using Bekk.Simple.Employee.Models;

namespace Bekk.Simple.Employee.Extensions
{
    public static class NewEmployeeViewModelExtension
    {
        public static Models.Employee ToEmployee(this NewEmployeeViewModel viewModel)
        {
            return new Models.Employee
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Department = new Department{Name = viewModel.Department}
            };
        }
    }
}