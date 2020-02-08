using ExampleSolution.WPF.Annotations;
using ExampleSolution.WPF.Commands;
using ExampleSolution.WPF.DataAccess;
using ExampleSolution.WPF.DataAccess.Interfaces;
using ExampleSolution.WPF.Models;
using ExampleSolution.WPF.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExampleSolution.WPF.ViewModels
{
    public class DepartmentsListViewModel : INotifyPropertyChanged
    {
        private readonly IDataAccess<Department> departmentDataAccess;

        private readonly WindowService windowService;

        private ObservableCollection<Department> departments;

        public RelayCommand<Department> SaveDepartmentCommand { get; }

        public RelayCommand<Department> AddEmployeeCommand { get; }

        public ObservableCollection<Department> Departments
        {
            get { return this.departments; }
            set
            {
                this.departments = value;
                this.OnPropertyChanged();
            }
        }

        public DepartmentsListViewModel()
        {
            this.windowService = new WindowService();

            this.departmentDataAccess = new DepartmentDataAccess();

            this.Departments = new ObservableCollection<Department>(this.departmentDataAccess.Get());

            this.SaveDepartmentCommand = new RelayCommand<Department>(d => !string.IsNullOrEmpty(d?.Name), this.SaveDepartment);
            this.AddEmployeeCommand = new RelayCommand<Department>(d => d != null, this.OpenAddEmployeeDialog);
        }

        private void OpenAddEmployeeDialog(Department department)
        {
            this.windowService.ShowAddEmployeeWindow(new AddEmployeeViewModel(department));
        }

        private void SaveDepartment(Department department)
        {
            this.departmentDataAccess.Save(department);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
