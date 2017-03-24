using ExampleSolution.WPF.Annotations;
using System;
using System.ComponentModel;

namespace ExampleSolution.WPF.Models
{
    public class ObservableEmployee : Employee, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public override Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                if (value.Equals(base.Id))
                {
                    return;
                }
                base.Id = value;
                this.OnPropertyChanged(nameof(this.Id));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string FirstName { get; set; }
        public override string MiddleName { get; set; }
        public override string LastName { get; set; }
        public override decimal Salary { get; set; }
        public override Guid DepartmentId { get; set; }
    }
}
