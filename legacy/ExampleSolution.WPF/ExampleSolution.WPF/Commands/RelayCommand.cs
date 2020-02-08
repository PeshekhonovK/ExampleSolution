using System;
using System.Windows.Input;

namespace ExampleSolution.WPF.Commands
{
    public class RelayCommand<T> : ICommand
    {
        protected T GetValue(object value)
        {
            return (T)value;
        }

        private Func<T, bool> canExecute;
        private Action<T> execute;

        public RelayCommand(Func<T, bool> canExecute, Action<T> execute, EventHandler canExecuteChanged = null)
        {
            this.canExecute = canExecute;
            this.execute = execute;
            this.CanExecuteChanged += canExecuteChanged;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute(this.GetValue(parameter));
        }

        public void Execute(object parameter)
        {
            this.execute(this.GetValue(parameter));
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
