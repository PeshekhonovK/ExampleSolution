using System.Threading.Tasks;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Contracts;

namespace EmployeeDirectory.DataAccess.Contracts
{
    public interface IDepartmentDataAccess
    {
        Task<Department> GetByAsync(IDepartmentContainer departmentId);
    }
}