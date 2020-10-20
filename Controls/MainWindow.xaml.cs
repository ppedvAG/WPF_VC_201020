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
        }

        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.DeepPink);

            Lbl_Output.Content = "Neuer String";

            //if (Cbb_Auswahl.SelectedItem != null)
            Tbl_Strings.Text = (Cbb_Auswahl.SelectedItem as ComboBoxItem)?.Content.ToString();

            MessageBox.Show(Sdr_Value.Value.ToString());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Application.Current.Shutdown();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow neuesFenster = new MainWindow();

            neuesFenster.ShowDialog();
        }
    }
}
