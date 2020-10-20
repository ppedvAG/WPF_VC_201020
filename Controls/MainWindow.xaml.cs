using System;
using System.Collections.Generic;
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

namespace Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Zuweisung eines weiteren EventHandlers zu dem CLick-Event des Buttons
            Btn_KlickMich.Click += Btn_KlickMich_Click_2;
        }

        //Event-Handler für das Click-Event des Buttons
        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            //Änderung der Hintergrundfarbe des Fensters
            this.Background = new SolidColorBrush(Colors.DeepPink);

            //Prüfung, ob die Checkbox abgehakt ist
            if (Cbx_Haken.IsChecked == true)
                //Neuzuweisung der Content-Eigenschaft des Labels
                Lbl_Output.Content = "Neuer String";

            //Neuzuweisung der Text-Eigenschaft des TextBlocks mit dem in der ComboBox ausgewählten Item
            Tbl_Strings.Text = (Cbb_Auswahl.SelectedItem as ComboBoxItem)?.Content.ToString();

            //Ausgabe des Values des Sliders in einer MessageBox
            MessageBox.Show(Sdr_Value.Value.ToString());
        }

        //Zweiter Eventhandeler des Buttons (siehe Konsruktor)
        private void Btn_KlickMich_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Schließen des aktuellen Fensters
            this.Close();
            //Schließen der kompletten Applikation
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //Öffen eines neuen Fensters als Dialogfenster
            MainWindow neuesFenster = new MainWindow();
            neuesFenster.ShowDialog();
        }
    }
}
