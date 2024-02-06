namespace Employees
{
    /// <summary>
    /// Employees Pair class that is an Row for the DataGrid collection
    /// </summary>
    public class EmployeePair : ViewModelBase
    {
        private int _emp1 = 0;
        private int _emp2 = 0;
        private int _prj = 0;
        private int _daysWorked = 0;

        public int Employee1 { get => _emp1; set => SetProperty(ref _emp1, value); }
        public int Employee2 { get => _emp2; set => SetProperty(ref _emp2, value); }
        public int ProjectId { get => _prj; set => SetProperty(ref _prj, value); }
        public int DaysWorked { get => _daysWorked; set => SetProperty(ref _daysWorked, value); }
    }
}
