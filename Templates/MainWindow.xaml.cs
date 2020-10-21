using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Templates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Properties vom Typ ObservableCollection informieren die GUI automatisch über Veränderungen (z.B. neuer Listeneintrag). Sie eignen sich besonders gut
        //für eine Bindung an ein ItemControl (z.B. ComboBox, ListBox, DataGrid, ...)
        public ObservableCollection<Person> Personenliste { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //Erstellen von Bsp-Daten
            Personenliste = new ObservableCollection<Person>()
            {
                new Person(){Vorname="Rainer", Nachname="Zufall", Alter=45},
                new Person(){Vorname="Anna", Nachname="Nass", Alter=19},
            };

            //Setzen des DataContext des Fensters auf sich selbst (Einfache Bindungen zu Properties in dieser Datei möglich)
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button-Klick funktioniert");
        }

        private void Btn_Altern_Click(object sender, RoutedEventArgs e)
        {
            //Erhöhung des Alters der Person im DataContextes des StackPanels
            (Spl_DataContext.DataContext as Person).Alter++;
            //Aufruf der 'Aktualisierungs-Methode' aus der Personen-Klasse
            (Spl_DataContext.DataContext as Person).AktualisiereGUI();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Personenliste.Add(new Person() { Vorname = "Hugo", Nachname = "Schmidt", Alter = 101 });
        }
    }
}
