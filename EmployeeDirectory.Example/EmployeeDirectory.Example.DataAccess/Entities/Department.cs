using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDirectory.Example.DataAccess.Entities
{
    public partial class Department
    {
        public Department()
        {
            this.Employee = new HashSet<Employee>();
            this.InverseParent = new HashSet<Department>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Department Parent { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Department> InverseParent { get; set; }
    }
}
