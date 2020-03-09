using System;
using System.Threading.Tasks;
using EmployeeDirectory.DataAccess.Contracts;
using EmployeeDirectory.Example.BLL.Contracts;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Contracts;
using EmployeeDirectory.Example.Domain.Models;

namespace EmployeeDirectory.Example.BLL.Implementation
{
    public class EmployeeUpdateService : IEmployeeUpdateService
    {
        private IEmployeeDataAccess EmployeeDataAccess { get; }
        private IDepartmentGetService DepartmentGetService { get; }
        
        public EmployeeUpdateService(IEmployeeDataAccess employeeDataAccess, IDepartmentGetService departmentGetService)
        {
            this.EmployeeDataAccess = employeeDataAccess;
            this.DepartmentGetService = departmentGetService;
        }

        public async Task<Employee> UpdateAsync(EmployeeUpdateModel employee)
        {
            await this.DepartmentGetService.ValidateAsync(employee);

            return await this.EmployeeDataAccess.UpdateAsync(employee);
        }
    }
}