using System;
using System.Threading.Tasks;
using EmployeeDirectory.DataAccess.Contracts;
using EmployeeDirectory.Example.BLL.Contracts;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Contracts;

namespace EmployeeDirectory.Example.BLL.Implementation
{
    public class DepartmentGetService : IDepartmentGetService
    {
        private IDepartmentDataAccess DepartmentDataAccess { get; }
        
        public DepartmentGetService(IDepartmentDataAccess departmentDataAccess)
        {
            this.DepartmentDataAccess = departmentDataAccess;
        }

        public async Task ValidateAsync(IDepartmentContainer departmentContainer)
        {
            if (departmentContainer == null)
            {
                throw new ArgumentNullException(nameof(departmentContainer));
            }
            
            var department = await this.GetBy(departmentContainer);

            if (departmentContainer.DepartmentId.HasValue && department == null)
            {
                throw new InvalidOperationException($"Department not found by id {departmentContainer.DepartmentId}");
            }
        }

        private async Task<Department> GetBy(IDepartmentContainer departmentContainer)
        {
            return await this.DepartmentDataAccess.GetByAsync(departmentContainer);
        }
    }
}