using MVVM_Personendatenbank.Hilfsklassen;
using MVVM_Personendatenbank.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace MVVM_Personendatenbank.ViewModel
{
    public class DetailViewModel
    {
        //Property, welche die neue oder zu bearbeitende Person beinhaltet
        public Person AktuellePerson { get; set; }

        //Command-Properties
        public CustomCommand OkCmd { get; set; }
        public CustomCommand CancelCmd { get; set; }

        public DetailViewModel()
        {
            //OK-Command (Bestätigung)
            OkCmd = new CustomCommand
                (
                    //CanExe: Kann immer ausgeführt werden. Eine Prüfung auf die Validierung der einzelnen Eingabefelder findet schon in der GUI (vgl. DetailView) statt.
                    p => true,
                    //Exe:
                    p =>
                    {
                        string ausgabe = AktuellePerson.Vorname + " " + AktuellePerson.Nachname + " (" + AktuellePerson.Geschlecht + ")\n" + AktuellePerson.Geburtsdatum.ToShortDateString() + "\n" + AktuellePerson.Lieblingsfarbe.ToString();
                        ausgabe += AktuellePerson.Verheiratet ? "\nIst Verheiratet" : "";

                        //Nachfrage auf Korrektheit der Daten per MessageBox
                        if (MessageBox.Show(ausgabe + "\nÜbernehmen?", "Person übertragen", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            //Setzen des DialogResults des Views (welches per Parameter übergeben wurde) auf true, damit das LIstView weiß, dass es weiter
                            //machen kann (d.h. die neuen Person einfügen bzw. austauschen)
                            (p as Window).DialogResult = true;
                            //Schließen des Views
                            (p as Window).Close();
                        }
                    }
                );

            //Abbruch-Cmd
            CancelCmd = new CustomCommand
                (
                    //CanExe: Kann immer ausgeführt werden
                    p => true,
                    //Exe: Schließen des Fensters
                    p => (p as Window).Close()
                );
        }
    }
}
