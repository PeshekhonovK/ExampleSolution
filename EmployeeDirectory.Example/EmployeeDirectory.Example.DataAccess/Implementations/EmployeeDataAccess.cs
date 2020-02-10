using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeDirectory.DataAccess.Context;
using EmployeeDirectory.DataAccess.Contracts;
using EmployeeDirectory.Example.DataAccess.Entities;
using EmployeeDirectory.Example.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Department = EmployeeDirectory.Example.Domain.Department;

namespace EmployeeDirectory.DataAccess.Implementations
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private EmployeeDirectoryContext Context { get; }
        private IMapper Mapper { get; }
        
        public EmployeeDataAccess(EmployeeDirectoryContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<Example.Domain.Employee> InsertAsync(EmployeeUpdateModel employee, Department department)
        {
            var result = await this.Context.AddAsync(new Employee
            {
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                DepartmentId = department?.Id
            });

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Example.Domain.Employee>(result.Entity);
        }

        public async Task<IEnumerable<Example.Domain.Employee>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Example.Domain.Employee>>(await this.Context.Employee.Include(x => x.Department).ToListAsync());
        }

        public async Task<Example.Domain.Employee> GetAsync(int employeeId)
        {
            var result = await this.Context.Employee
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.Id == employeeId);

            return this.Mapper.Map<Example.Domain.Employee>(result);
        }
    }
}