using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Templates
{
    //Das Interface INotifyPropertyChanged ist dafür verantwortlich, dass die GUI über Veränderungen in den Properties informiert wird
    //und somit diese Veränderungen abbilden kann.
    public class Person : INotifyPropertyChanged
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        private int alter;
        public int Alter
        {
            get { return alter; }
            set 
            { 
                alter = value;
                //Aufruf des PropertyChanged-Events im Setter (dort wo die Veränderung durchgeführt wird) mit Übergabe des Event-Senders und der veränderten Property
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        //Durch das Interface gefordertes Event
        public event PropertyChangedEventHandler PropertyChanged;

        public void AktualisiereGUI()
        {
            //Manueller Aufruf des PropertyChanged-Events (als Ersatz für den oben verwendeten Aufruf im Setter)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
        }
    }
}
