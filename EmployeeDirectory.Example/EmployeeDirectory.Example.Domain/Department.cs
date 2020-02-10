using System;

namespace EmployeeDirectory.Example.Domain
{
    public class Department
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Department Parent { get; set; }
    }
}