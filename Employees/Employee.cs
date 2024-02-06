using System;

namespace Employees
{
    /// <summary>
    /// Employee
    /// Representing employee with start and end date for a project
    /// </summary>
    public struct Employee
    {
        public Employee(int iD, DateTime startDate, DateTime endDate)
        {
            ID = iD;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int ID { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}
