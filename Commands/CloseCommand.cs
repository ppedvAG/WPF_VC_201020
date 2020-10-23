using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Commands
{
    public class CloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return (parameter as Window).Width < 150;

            //return (parameter as MainWindow).Tbx_Input.Text.Length > 0;
        }

        public void Execute(object parameter)
        {
            (parameter as Window).Close();
        }
    }
}
