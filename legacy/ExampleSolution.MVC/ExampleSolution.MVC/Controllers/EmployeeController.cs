using ExampleSolution.MVC.ExampleService;
using ExampleSolution.MVC.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExampleSolution.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<ActionResult> Employee(Guid? employeeId, Guid departmentId)
        {
            using (var service = new ExampleServiceClient())
            {
                var employee = employeeId.HasValue ? new Employee().MapFrom(await service.GetEmployeeAsync(employeeId.Value)) : null;

                var model = new EditEmployeeModel
                {
                    Id = employeeId ?? Guid.Empty,
                    FirstName = employee?.FirstName,
                    LastName = employee?.LastName,
                    MiddleName = employee?.MiddleName,
                    DepartmentId = departmentId,
                    AvailableDepartments = service.GetDepartments().Select(x => new Department().MapFrom(x)).ToArray(),
                    CurrentDepartmentId = departmentId
                };

                return this.View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Save(EditEmployeeModel employee)
        {
            using (var service = new ExampleServiceClient())
            {
                if (this.ModelState.IsValid)
                {
                    var dto = new EmployeeDTO
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        MiddleName = employee.MiddleName
                    };

                    await service.SaveEmployeeAsync(dto, service.GetDepartmentById(employee.DepartmentId));

                    return this.RedirectToAction("EmployeeList", "Departments", new { departmentId = employee.CurrentDepartmentId });
                }

                var availableDepartmentsDTO = await service.GetDepartmentsAsync();
                employee.AvailableDepartments = availableDepartmentsDTO.Select(x => new Department().MapFrom(x)).ToArray();

                return this.View("Employee", employee);
            }
        }
    }
}