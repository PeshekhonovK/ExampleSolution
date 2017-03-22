using Example.Domain;
using System;
using System.Collections.Generic;

namespace Example.BLL
{
    public interface IDepartmentBLL
    {
        /// <summary>
        /// Creates new Department
        /// </summary>
        Department CreateNew(string name);

        /// <summary>
        /// Sets new Department to all Employees in <paramref name="source"/> to <paramref name="target"/>
        /// </summary>
        void MoveAllEmployeesTo(Department source, Department target);

        ICollection<Department> GetAll();

        Department GetById(Guid id);
    }
}