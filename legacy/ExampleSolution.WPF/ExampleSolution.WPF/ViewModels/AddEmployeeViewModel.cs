using ExampleSolution.WPF.Annotations;
using ExampleSolution.WPF.Commands;
using ExampleSolution.WPF.DataAccess;
using ExampleSolution.WPF.DataAccess.Interfaces;
using ExampleSolution.WPF.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ExampleSolution.WPF.ViewModels
{
    public class AddEmployeeViewModel : INotifyPropertyChanged
    {
        private readonly IDataAccess<Employee> employeeDataAccess;

        private readonly Department department;

        public Employee NewEmployee { get; set; }

        public RelayCommand<Employee> SaveCommand { get; }
        public RelayCommand<Window> CancelCommand { get; }

        public AddEmployeeViewModel()
        {
            this.employeeDataAccess = new EmployeeDataAccess();

            this.SaveCommand = new RelayCommand<Employee>(e => !string.IsNullOrEmpty(e?.FirstName + e?.MiddleName + e?.LastName), this.SaveEmployee);
            this.CancelCommand = new RelayCommand<Window>(_ => true, w => w.Close());
        }

        public AddEmployeeViewModel(Department department) : this()
        {
            this.department = department;
            this.NewEmployee = new Employee { DepartmentId = department.Id };
        }

        private void SaveEmployee(Employee employee)
        {
            this.employeeDataAccess.Save(employee);
            this.department.Employees.Add(employee);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
