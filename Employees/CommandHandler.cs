﻿using System;
using System.Windows;
using System.Windows.Input;

namespace Employees
{
    /// <summary>
    ///Class for binding command to a button through the view model
    ///Not mine! 
    /// </summary>
    public class CommandHandler : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;

        /// <summary>
        /// Creates instance of the command handler
        /// </summary>
        /// <param name="action">Action to be executed by the command</param>
        /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
        public CommandHandler(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public CommandHandler(Action action)
        {
            _action = action;
            _canExecute = () => true;
        }
        /// <summary>
        /// Wires CanExecuteChanged event 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Forcess checking if execute is allowed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            try
            {
                _action();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
