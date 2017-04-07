using ExampleSolution.MVC.ExampleService;
using ExampleSolution.MVC.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExampleSolution.MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public async Task<ActionResult> Departments()
        {
            using (var service = new ExampleServiceClient())
            {
                var departments = await service.GetDepartmentsAsync();

                return this.View(departments.Select(x => new Department().MapFrom(x)).ToArray());
            }
        }

        public async Task<ActionResult> EmployeeList(Guid departmentId)
        {
            using (var service = new ExampleServiceClient())
            {
                var department = await service.GetDepartmentByIdAsync(departmentId);

                return this.View(new Department().MapFrom(department));
            }
        }
    }
}