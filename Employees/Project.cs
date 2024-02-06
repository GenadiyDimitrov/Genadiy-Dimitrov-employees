using System;
using System.Collections.Generic;
using System.Linq;

namespace Employees
{
    /// <summary>
    /// Project class, with a collection of employees that have worked on it.
    /// </summary>
    public class Project
    {
        public int ID { get; private set; }
        public Dictionary<int, Employee> Employees { get; private set; }

        public Project(int id)
        {
            ID = id;
            Employees = new();
        }
        /// <summary>
        /// Try to add employee.
        /// </summary>
        /// <param name="employee">And employee generated from the input csv file</param>
        public bool TryAddEmployee(Employee employee)
        {
            if (Employees.ContainsKey(employee.ID)) return false;

            Employees.Add(employee.ID, employee);
            return true;
        }
        /// <summary>
        /// Get the employees pairs.
        /// Only pairs will be returned. If one of the employees is missing its not counted as a pair.
        /// </summary>
        public IEnumerable<EmployeePair> GetEmployeePairs()
        {
            //Create empty pairs list
            var list = new List<EmployeePair>();
            //Get only empoloyees
            var employees = Employees.Values.ToArray();
            //Get pairs. Length - 1 because we need a pair. Last one won't be a pair
            for (int a = 0; a < employees.Length - 1; a++)
            {
                //Start from next index because we already have the first two as pair.
                for (int b = a + 1; b < employees.Length; b++)
                {
                    //First employee
                    var emp1 = employees[a];
                    //Second employee
                    var emp2 = employees[b];
                    int daysWorked = 0;
                    //If both have overlapping time, that mean they worked together on the current project
                    if (emp1.EndDate.Date > emp2.StartDate.Date && emp2.EndDate.Date > emp1.StartDate.Date)
                    {
                        //Get last date that employee joined the pair
                        DateTime startDateForBothEmployees = emp1.StartDate.Max(emp2.StartDate);
                        //Get the first date that employee left the pair
                        DateTime endDateForBothEmployees = emp1.EndDate.Min(emp2.EndDate);

                        //We compare and get the actual days
                        daysWorked = (int)(endDateForBothEmployees.Date - startDateForBothEmployees.Date).TotalDays;
                    }

                    //Uncomment if we need only pairs that worked together, with overlapping times.
                    /*
                      if (daysWorked <= 0) continue;
                     */

                    //Create a pair
                    list.Add(new EmployeePair()
                    {
                        Employee1 = emp1.ID,
                        Employee2 = emp2.ID,
                        ProjectId = this.ID,
                        DaysWorked = daysWorked
                    });
                }
            }
            return list;
        }
    }
}
