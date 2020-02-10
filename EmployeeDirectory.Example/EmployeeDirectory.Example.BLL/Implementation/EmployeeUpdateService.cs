using System.Threading.Tasks;
using EmployeeDirectory.Example.BLL.Contracts;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Models;

namespace EmployeeDirectory.Example.BLL.Implementation
{
    public class EmployeeUpdateService : IEmployeeUpdateService
    {
        public Task<Employee> UpdateAsync(EmployeeUpdateModel map)
        {
            throw new System.NotImplementedException();
        }
    }
}