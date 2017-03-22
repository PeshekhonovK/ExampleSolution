using Example.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.DAL
{
    public class Repository : IRepository
    {
        public Employee GetEmployeeById(Guid id)
        {
            using (var context = new ExampleContext())
            {
                return this.GetEmployeeById(id, context);
            }
        }

        public Employee Save(Employee employee)
        {
            using (var context = new ExampleContext())
            {
                var result = this.SaveEmployee(employee, context);

                context.SaveChanges();

                return result;
            }
        }

        public ICollection<Employee> Save(params Employee[] employees)
        {
            using (var context = new ExampleContext())
            {
                var result = this.SaveEmployees(employees, context);

                context.SaveChanges();

                return result;
            }
        }

        public Department GetDepartmentById(Guid id)
        {
            using (var context = new ExampleContext())
            {
                return this.GetDepartmentById(id, context);
            }
        }

        public Department Save(Department department)
        {
            using (var context = new ExampleContext())
            {
                var result = this.SaveDepartment(department, context);

                context.SaveChanges();

                return result;
            }
        }

        public ICollection<Department> Save(params Department[] departments)
        {
            using (var context = new ExampleContext())
            {
                var result = this.SaveDepartments(departments, context);

                context.SaveChanges();

                return result;
            }
        }

        public ICollection<Department> GetAllDepartments()
        {
            using (var context = new ExampleContext())
            {
                return context.Departments.ToArray().Select(x => x.MapToModel()).ToArray();
            }
        }

        private ICollection<Department> SaveDepartments(ICollection<Department> departments, ExampleContext context)
        {
            var results = new List<Department>();

            foreach (var department in departments)
            {
                results.Add(this.SaveDepartment(department, context));
            }

            return results;
        }

        private Employee GetEmployeeById(Guid id, ExampleContext context)
        {
            var result = context.Employees.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return result.MapToModel(result.Department.MapToModel());
        }

        private ICollection<Employee> SaveEmployees(ICollection<Employee> employees, ExampleContext context)
        {
            var results = new List<Employee>();

            foreach (var employee in employees)
            {
                results.Add(this.SaveEmployee(employee, context));
            }

            return results;
        }

        private Employee SaveEmployee(Employee employee, ExampleContext context)
        {
            EmployeeEntity changingEntity;

            var department = this.GetDepartmentByIdInner(employee.Department.Id, context);
            if (employee.Id != Guid.Empty)
            {
                changingEntity = context.Employees.First(x => x.Id == employee.Id).MapToEntity(employee, department);
            }
            else
            {
                changingEntity = new EmployeeEntity().MapToEntity(employee, department);
                changingEntity.Id = Guid.NewGuid();
                context.Employees.Add(changingEntity);
            }

            var model = changingEntity.MapToModel(department.MapToModel());

            return model;
        }

        private Department GetDepartmentById(Guid id, ExampleContext context)
        {
            var result = this.GetDepartmentByIdInner(id, context);

            if (result == null)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return result.MapToModel();
        }

        private DepartmentEntity GetDepartmentByIdInner(Guid id, ExampleContext context)
        {
            return context.Departments.Include(nameof(Department.Employees)).FirstOrDefault(x => x.Id == id);
        }

        private Department SaveDepartment(Department department, ExampleContext context)
        {
            DepartmentEntity result;

            if (department.Id != Guid.Empty)
            {
                result = context.Departments.First(x => x.Id == department.Id).MapToEntity(department);
            }
            else
            {
                result = new DepartmentEntity().MapToEntity(department);
                result.Id = Guid.NewGuid();
                context.Departments.Add(result);
            }

            return result.MapToModel();
        }
    }
}
