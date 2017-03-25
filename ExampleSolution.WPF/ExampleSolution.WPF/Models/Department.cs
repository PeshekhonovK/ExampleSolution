using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExampleSolution.WPF.Annotations;

namespace ExampleSolution.WPF.Models
{
    public class Department : INotifyPropertyChanged
    {
        private ObservableCollection<Employee> employees;
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ObservableCollection<Employee> Employees
        {
            get { return this.employees; }
            set
            {
                this.employees = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
