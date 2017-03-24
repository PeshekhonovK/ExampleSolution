using System.Windows;

namespace ExampleSolution.WPF
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee(object dataContext)
        {
            this.DataContext = dataContext;
            this.InitializeComponent();
        }
    }
}
