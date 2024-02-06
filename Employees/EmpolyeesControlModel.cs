using System.Collections.ObjectModel;

namespace Employees
{
    /// <summary>
    /// Employees Control Model that contains the collection of pairs
    /// </summary>
    public class EmpolyeesControlModel : ViewModelBase
    {
        public ObservableCollection<EmployeePair> _employeePairs;
        public EmpolyeesControlModel()
        {
            _employeePairs = new();
        }

        //Employees Pairs -  Shows all Pairs for a project
        //If needed can be exported/saved
        public ObservableCollection<EmployeePair> EmployeePairs { get => _employeePairs; set => SetProperty(ref _employeePairs, value); }
    }
}
