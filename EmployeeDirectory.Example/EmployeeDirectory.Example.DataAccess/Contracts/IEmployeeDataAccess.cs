using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Models;

namespace EmployeeDirectory.DataAccess.Contracts
{
    public interface IEmployeeDataAccess
    {
        Task<Employee> InsertAsync(EmployeeUpdateModel employee, Department department);
        Task<IEnumerable<Employee>> GetAsync();
        Task<Employee> GetAsync(int employeeId);
    }
}