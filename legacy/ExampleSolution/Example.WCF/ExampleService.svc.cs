﻿using Example.BLL;
using Example.DAL;
using Example.DTO;
using Example.WCF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.WCF
{
    public class ExampleService : IExampleService
    {
        private readonly IRepository repository;
        private readonly IDepartmentBLL departmentBLL;
        private readonly IEmployeeBLL employeeBLL;

        public ExampleService(IRepository repository, IDepartmentBLL departmentBll, IEmployeeBLL employeeBll)
        {
            this.repository = repository;
            this.departmentBLL = departmentBll;
            this.employeeBLL = employeeBll;
        }

        public ICollection<EmployeeDTO> GetEmployeesByDepartment(Guid departmentId)
        {
            var department = this.repository.GetDepartmentById(departmentId);

            return this.employeeBLL.GetEmployeesByDepartment(department).Select(x => new EmployeeDTO().MapFromModel(x)).ToArray();
        }

        public EmployeeDTO CreateNewEmployee(string firstName, string middleName, string lastName, decimal salary, Guid departmentId)
        {
            var department = this.repository.GetDepartmentById(departmentId);

            var result = this.employeeBLL.Register(lastName, firstName, middleName, department, salary);

            return new EmployeeDTO().MapFromModel(result);
        }

        public DepartmentDTO CreateNewDepartment(string name)
        {
            var newDepartment = this.departmentBLL.CreateNew(name);

            return new DepartmentDTO().MapFromModel(newDepartment);
        }

        public ICollection<DepartmentDTO> GetDepartments()
        {
            return this.departmentBLL.GetAll().Select(x => new DepartmentDTO().MapFromModel(x)).ToArray();
        }

        public DepartmentDTO UpdateDepartment(DepartmentDTO department)
        {
            return new DepartmentDTO().MapFromModel(this.repository.Save(department.MapToModel()));
        }

        public EmployeeDTO GetEmployee(Guid employeeId)
        {
            return new EmployeeDTO().MapFromModel(this.repository.GetEmployeeById(employeeId));
        }

        public DepartmentDTO GetDepartmentById(Guid departmentId)
        {
            return new DepartmentDTO().MapFromModel(this.repository.GetDepartmentById(departmentId));
        }

        public void SaveEmployee(EmployeeDTO employee, DepartmentDTO department)
        {
            this.repository.Save(employee.MapToModel(department.MapToModel()));
        }
    }
}
