using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Employees
{
    /// <summary>
    /// Employees ViewModel for additional Bindings and logic
    /// </summary>
    public class EmployeesControlViewModel : ViewModelBase
    {
        //Fields
        private EmpolyeesControlModel _model;
        private string _fileName;
        private Dictionary<int, Project> _projects;

        //Ctor
        public EmployeesControlViewModel()
        {
            _projects = new();
            _fileName = "";
            _model = new();
        }

        //Props
        public string FileName { get => _fileName; set => SetProperty(ref _fileName, value); }
        public ObservableCollection<EmployeePair> EmployeePairs => _model.EmployeePairs;
        //Commands
        public ICommand FileOpenCommand => new CommandHandler(FileOpen);

        /// <summary>
        /// Open file Dialogue after button click
        /// </summary>
        private void FileOpen()
        {
            _projects.Clear();
            _model.EmployeePairs.Clear();
            OpenFileDialog openFileDialog = new()
            {
                Filter = "CSV files (*.csv)|*.csv"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                //Update the TextBlock.Text property
                FileName = openFileDialog.SafeFileName;
                //Start to calculate pairs to show in dataGrid
                GenerateCollection(openFileDialog.FileName);
            }
        }
        /// <summary>
        /// Start to calculate pairs to show in dataGrid
        /// </summary>
        /// <param name="path">File path</param>
        private void GenerateCollection(string path)
        {
            string[] lines = GetLinesFromFile(path);
            UpdateProjectsCollection(lines);
            UpdateEmployeesPairs();
        }
        /// <summary>
        /// Read lines from the text files
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>String array</returns>
        private string[] GetLinesFromFile(string path)
        {
            return File.ReadAllLines(path);
        }
        /// <summary>
        /// Take lines, validates them and update the Projects collection
        /// </summary>
        private void UpdateProjectsCollection(string[] lines)
        {
            foreach (string line in lines)
            {
                if (Validate.ValidateRow(line, out int projectId) is Employee employee)
                {
                    Project project;
                    if (!_projects.TryGetValue(projectId, out project))
                    {
                        project = new(projectId);
                        _projects.Add(projectId, project);
                    }
                    project.TryAddEmployee(employee);
                }
            }
        }
        /// <summary>
        /// Generate actual pairs and shows them in DataGrid
        /// </summary>
        private void UpdateEmployeesPairs()
        {
            foreach (Project project in _projects.Values)
            {
                foreach (var pair in project.GetEmployeePairs())
                {
                    _model.EmployeePairs.Add(pair);
                }
            }
        }
    }
}
