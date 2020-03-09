using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Contracts;
using EmployeeDirectory.Example.Domain.Models;

namespace EmployeeDirectory.DataAccess.Contracts
{
    public interface IEmployeeDataAccess
    {
        Task<Employee> InsertAsync(EmployeeUpdateModel employee);
        Task<IEnumerable<Employee>> GetAsync();
        Task<Employee> GetAsync(IEmployeeIdentity employeeId);
        Task<Employee> UpdateAsync(EmployeeUpdateModel employee);
    }
}