using MVVM_Personendatenbank.Hilfsklassen;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM_Personendatenbank.ViewModel
{
    public class StartViewModel : INotifyPropertyChanged
    {
        public int AnzahlPersonen { get { return Model.Person.Personenliste.Count; } }

        public CustomCommand LoadCmd { get; set; }

        public CustomCommand OpenCmd { get; set; }

        public StartViewModel()
        {
            LoadCmd = new CustomCommand
                (
                    p => this.AnzahlPersonen <= 0,
                    p =>
                    {
                        Model.Person.LadePersonenAusDb();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnzahlPersonen)));
                    }
                ) ;
            OpenCmd = new CustomCommand
                (
                    p => this.AnzahlPersonen > 0,
                    p => { }
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
