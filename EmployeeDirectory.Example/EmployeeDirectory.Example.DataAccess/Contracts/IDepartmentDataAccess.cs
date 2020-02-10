using System.Threading.Tasks;
using EmployeeDirectory.Example.Domain;

namespace EmployeeDirectory.DataAccess.Contracts
{
    public interface IDepartmentDataAccess
    {
        Task<Department> GetByAsync(int departmentId);
    }
}