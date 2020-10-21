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

namespace EventRouting
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

        //Event, welches von den StackPanels während der Tunneling-Phase geworfen wird
        private void SP_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Ausgabe des Namens des werfenden StackPanles (sender)
            Tbl_Output.Text += (sender as StackPanel).Name + " Tunnel\n";
        }

        //Event, welches von den StackPanels während der Bubbleing-Phase geworfen wird
        private void SP_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tbl_Output.Text += (sender as StackPanel).Name + " Bubbel\n";

            //Das Event wird gehandelt (= Weiterleitung wird unterbunden), wenn der Name des werfenden StackPanels "Gelb" ist
            if ((sender as StackPanel).Name == "Grün") e.Handled = true;
        }

        //Direkt-Event, welches vom Button ausgelöst wird (Handled die Events automatisch)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tbl_Output.Text += "CLICK\n";
        }
    }
}
