using MVVM_Personendatenbank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MVVM_Personendatenbank.Hilfsklassen;
using System.Windows;
using MVVM_Personendatenbank.View;
using System.Diagnostics;

namespace MVVM_Personendatenbank.ViewModel
{
    public class ListViewModel
    {
        //Listen-Property, welche auf die Liste des Models verlinkt
        public ObservableCollection<Person> Personenliste { get { return Model.Person.Personenliste; } }

        //Command-Properties
        public CustomCommand NewCmd { get; set; }
        public CustomCommand ChangeCmd { get; set; }
        public CustomCommand DeleteCmd { get; set; }
        public CustomCommand CloseCmd { get; set; }

        public ListViewModel()
        {
            //Command-Definitionen
            //Hinzufügen einer neuen Person
            NewCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    p => true,
                    //Exe:
                    p =>
                    {
                        //Instanzieren eines neuen DetailViews
                        DetailView personen_Dialog = new DetailView();

                        //(NeuePerson_Dialog.DataContext as DetailViewModel).AktuellePerson = new Person();

                        //Erstellung eines neuen DetailViewModels als dessen DataContext
                        DetailViewModel detailViewModel = new DetailViewModel();

                        //Zuweisung einer neuen Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        detailViewModel.AktuellePerson = new Person();

                        //Zuweisung des ViewModels als DataContext für das View
                        personen_Dialog.DataContext = detailViewModel;

                        //Aufruf des DetailViews mit Überprüfung auf dessen DialogResult(wird true, wenn der Benutzer OK klickt)
                        if (personen_Dialog.ShowDialog() == true)
                            //Hinzufügen der neuen Person zu Liste
                            Model.Person.Personenliste.Add(detailViewModel.AktuellePerson);
                    }
                );

            //Ändern einer bestehenden Person
            ChangeCmd = new CustomCommand
                (
                    //CanExe: Kann ausgeführt werden, wenn der Parameter (der im DataGrid ausgewählte Eintrag) eine Person ist.
                    //Fungiert als Null-Prüfung
                    p => p is Person,
                    //Exe:
                    p =>
                    {
                        //Vgl. NeuCmd (s.o.)
                        DetailView personen_Dialog = new DetailView();
                        DetailViewModel detailViewModel = new DetailViewModel();

                        //Zuweisung einer Kopie der ausgewählten Person in die 'AktuellePerson'-Property des neuen DetailViewModels
                        detailViewModel.AktuellePerson = new Person(p as Person);

                        //Ändern des Titels des neuen DetailViews
                        personen_Dialog.Title = (p as Person).Vorname + " " + (p as Person).Nachname;

                        personen_Dialog.DataContext = detailViewModel;

                        if (personen_Dialog.ShowDialog() == true)
                        {
                            //Ermittlung des Index der ausgewählten Person
                            int index = Model.Person.Personenliste.IndexOf(p as Person);
                            //Austausch der (veränderten) Person-Kopie mit dem Original in der Liste
                            Model.Person.Personenliste[index] = detailViewModel.AktuellePerson;
                        }
                    }
                );

            //Löschen einer Person
            DeleteCmd = new CustomCommand
                (
                    //CanExe: s.o.
                    p => p is Person,
                    //Exe: Löschen der ausgewählten Person (nach Rückfrage per MessageBox)
                    p =>
                    {
                        Person person = p as Person;
                        if (MessageBox.Show($"Soll {person.Vorname} {person.Nachname} wrklich gelöscht werden?", "Löschen", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            Model.Person.Personenliste.Remove(person);
                    }
                );

            //Schließen des Programms
            CloseCmd = new CustomCommand
                (
                    //CanExe: kann immer ausgeführt werden
                    p => true,
                    //Exe: Schließen der Applikation
                    p => Application.Current.Shutdown()
                );
        }
    }
}
