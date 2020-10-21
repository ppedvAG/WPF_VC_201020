using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Templates
{
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
