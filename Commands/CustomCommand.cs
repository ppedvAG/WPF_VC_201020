using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Commands
{
    //Commandklassen müssen das Interface ICommand implementieren
    public class CustomCommand : ICommand
    {
        //Diese Command-Klasse ist nicht spezialisiert. Sie kann über den Konstruktor mit beliebigen Methoden befüllt werden

        //Properties
        public Func<object, bool> CanExecuteMethode { get; set; }
        public Action<object> ExecuteMethode { get; set; }

        //Konstruktor
        public CustomCommand(Func<object, bool> can, Action<object> exe)
        {
            CanExecuteMethode = can;
            ExecuteMethode = exe;
        }

        //Anmeldung des Events am CommandManager der Applikation (-> informiert Views über Veränderungen der Rückgabe der CanExecute()-Methode)
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Methoden
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
