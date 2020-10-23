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

namespace Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Command-Properties        
        public CloseCommand CloseCmd { get; set; }
        public CustomCommand OpenCmd { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            CloseCmd = new CloseCommand();

            //Initialisierung des Commands mit Übergabe der beiden benötigten Methoden in Lamda-Schreibweise
            OpenCmd = new CustomCommand
                (
                    p => (p as Window).Width < 150,
                    p => new MainWindow().Show()
                );

            //Setzen des DataContext, damit die Kurzbindung an das Command funktioniert
            this.DataContext = this;
        }
    }
}
