using System.Windows.Controls;

namespace Employees
{
    /// <summary>
    /// Actual View for the Assignement
    /// </summary>
    public partial class EmployeesControl : Grid
    {
        public EmployeesControl()
        {
            //Add a data context for binding
            DataContext = new EmployeesControlViewModel();
            InitializeComponent();
        }
    }
}
