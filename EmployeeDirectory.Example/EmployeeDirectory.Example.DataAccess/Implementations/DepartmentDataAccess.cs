using System.Threading.Tasks;
using AutoMapper;
using EmployeeDirectory.DataAccess.Context;
using EmployeeDirectory.DataAccess.Contracts;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.DataAccess.Implementations
{
    public class DepartmentDataAccess : IDepartmentDataAccess
    {
        private EmployeeDirectoryContext Context { get; }
        private IMapper Mapper { get; }
        
        public DepartmentDataAccess(EmployeeDirectoryContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Department> GetByAsync(IDepartmentContainer department)
        {
            return department.DepartmentId.HasValue 
                ? this.Mapper.Map<Department>(await this.Context.Department.FirstOrDefaultAsync(x => x.Id == department.DepartmentId)) 
                : null;
        }
    }
}