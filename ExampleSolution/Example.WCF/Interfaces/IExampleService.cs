using Example.DTO;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Example.WCF.Interfaces
{
    [ServiceContract]
    public interface IExampleService
    {
        [OperationContract]
        ICollection<EmployeeDTO> GetEmployeesByDepartment(Guid departmentId);

        [OperationContract]
        EmployeeDTO CreateNewEmployee(string firstName, string middleName, string lastName, decimal salary, Guid departmentId);

        [OperationContract]
        DepartmentDTO CreateNewDepartment(string name);

        [OperationContract]
        ICollection<DepartmentDTO> GetDepartments();

        [OperationContract]
        DepartmentDTO GetDepartmentById(Guid departmentId);

        [OperationContract]
        DepartmentDTO UpdateDepartment(DepartmentDTO department);

        [OperationContract]
        EmployeeDTO GetEmployee(Guid employeeId);

        [OperationContract]
        void SaveEmployee(EmployeeDTO employee, DepartmentDTO department);
    }
}
