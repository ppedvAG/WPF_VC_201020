using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MVVM_Personendatenbank.Hilfsklassen
{
    public class CustomCommand : ICommand
    {
        public Func<object, bool> CanExecuteMethode { get; set; }

        public Action<object> ExecuteMethode { get; set; }

        public CustomCommand(Func<object, bool> can, Action<object> exe)
        {
            CanExecuteMethode = can;
            ExecuteMethode = exe;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteMethode(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteMethode(parameter);
        }
    }
}
