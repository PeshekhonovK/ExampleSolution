using ExampleSolution.WPF.ViewModels;

namespace ExampleSolution.WPF.Services
{
    public class WindowService
    {
        public void ShowAddEmployeeWindow(AddEmployeeViewModel dataContext)
        {
            var window = new AddEmployee(dataContext);

            window.Show();
        }
    }
}
