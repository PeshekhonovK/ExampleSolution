using System;
using System.Threading.Tasks;
using EmployeeDirectory.DataAccess.Contracts;
using EmployeeDirectory.Example.BLL.Contracts;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Models;

namespace EmployeeDirectory.Example.BLL.Implementation
{
    public class EmployeeCreateService : IEmployeeCreateService
    {
        private IEmployeeDataAccess EmployeeDataAccess { get; }
        private IDepartmentGetService DepartmentGetService { get; }
        
        public EmployeeCreateService(IEmployeeDataAccess employeeDataAccess, IDepartmentGetService departmentGetService)
        {
            this.EmployeeDataAccess = employeeDataAccess;
            this.DepartmentGetService = departmentGetService;
        }

        public async Task<Employee> CreateAsync(EmployeeUpdateModel employee)
        {
            await this.DepartmentGetService.ValidateAsync(employee);
            
            return await this.EmployeeDataAccess.InsertAsync(employee);
        }
    }
}