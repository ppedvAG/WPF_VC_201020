using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Personendatenbank
{
    /// <summary>
    /// Interaction logic for DbAnsicht.xaml
    /// </summary>
    public partial class DbAnsicht : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; }

        public DbAnsicht()
        {
            InitializeComponent();

            Personenliste = new ObservableCollection<Person>()
            {
                new Person(){Vorname="Anna", Nachname="Nass", Geburtsdatum=new DateTime(1988, 4, 13), Verheiratet=false, Lieblingsfarbe=Colors.Red, Geschlecht=Gender.Weiblich},
                new Person(){Vorname="Rainer", Nachname="Zufall", Geburtsdatum=new DateTime(1987, 5, 22), Verheiratet=true, Lieblingsfarbe=Colors.Green, Geschlecht=Gender.Männlich},
            };

            this.DataContext = this;
        }

        private void MeI_Beenden_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            Personendialog dialog = new Personendialog();

            if (dialog.ShowDialog() == true)
                Personenliste.Add(dialog.NeuePerson);
        }

        private void Btn_Aendern_Click(object sender, RoutedEventArgs e)
        {
            if (Dgd_Personen.SelectedItem is Person)
            {
                Personendialog dialog = new Personendialog();

                dialog.NeuePerson = new Person(Dgd_Personen.SelectedItem as Person);

                dialog.DataContext = dialog.NeuePerson;

                dialog.Title = dialog.NeuePerson.Vorname + " " + dialog.NeuePerson.Nachname;

                if (dialog.ShowDialog() == true)
                    Personenliste[Dgd_Personen.SelectedIndex] = dialog.NeuePerson;
            }
        }

        private void Btn_Loeschen_Click(object sender, RoutedEventArgs e)
        {
            Person person = Dgd_Personen.SelectedItem as Person;
            if (MessageBox.Show($"Soll {person.Vorname} {person.Nachname} wrklich gelöscht werden?", "Löschen", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Personenliste.Remove(person);
        }
    }
}
