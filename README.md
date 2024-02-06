# TASK:
## Pair of employees who have worked together
_Create an application that identifies the pair of employees who have worked  
together on common projects for the longest period of time._

### Input data:
 A CSV file with data in the following format:  
 EmpID, ProjectID, DateFrom, DateTo
### Sample data:
143, 12, 2013-11-01, 2014-01-05  
218, 10, 2012-05-16, NULL  
143, 10, 2009-01-01, 2011-04-27  
...  
### Sample output:
 143, 218, 8  
#### Specific requirements
1. DateTo can be NULL, equivalent to today
2. The input data must be loaded to the program from a CSV file
3. The task solution needs to be uploaded in github.com, repository name must be in
format: {FirstName}-{LastName}-employees
#### Bonus points
1. Create an UI:
The user picks up a file from the file system and, after selecting it, all common
projects of the pair are displayed in datagrid with the following columns:
Employee ID #1, Employee ID #2, Project ID, Days worked
2. More than one date format to be supported, extra points will be given if all date formats
are supported

# How it works
1. Start the program
2. Click "Load File"
3. If valid file - The result is shown in the table

# Visualisation
1. File picker
2. DataGrid with result

# Solution (My Interpretation)
1. A program that takes .csv file
   - Validate each row of data
   - Time formats could be altered
     - Can be modified inside the code.
     - Can be made into a settings file
     - Can make a TextBox for inputing currents file format
     - Or can be taken from the first Date field and set as format for the whole file
   - The current DateTime formats are all possible variations of dd MM yyyy
     - Not dependent on separator
2. Splt the file and generates "projects" with collection of employees
3. For each project we find the pairs of employees
   - If 3 or more employees have worked on the same project there will be 3+ pairs
     - 1+2 and 1+3 and 2+3 ... etc.
4. All pairs are shown.
   - Only oerlapping times are calculated
   - If a pair dont have overlapping time their DaysWorked is 0
   - If only one employee have worked on a project it wont show
5.The result is Shown in dataGrid
