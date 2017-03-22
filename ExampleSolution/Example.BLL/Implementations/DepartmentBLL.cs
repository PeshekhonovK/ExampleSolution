using Example.DAL;
using Example.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.BLL
{
    public class DepartmentBLL : IDepartmentBLL
    {
        private readonly IEmployeeBLL employeeBLL;
        private readonly IRepository repository;

        public DepartmentBLL(IRepository repository, IEmployeeBLL employeeBll)
        {
            this.employeeBLL = employeeBll;
            this.repository = repository;
        }

        public Department CreateNew(string name)
        {
            var result = new Department(name);

            return this.repository.Save(result);
        }

        public void MoveAllEmployeesTo(Department source, Department target)
        {
            if (source == target)
            {
                throw new ArgumentException($"Employees cannot be move to same department \"{source.Name}\"");
            }

            while (source.Employees.Any())
            {
                this.employeeBLL.Move(source.Employees.First(), target);
            }

            this.repository.Save(source, target);
        }

        public ICollection<Department> GetAll()
        {
            return this.repository.GetAllDepartments();
        }

        public Department GetById(Guid id)
        {
            return this.repository.GetDepartmentById(id);
        }
    }
}
