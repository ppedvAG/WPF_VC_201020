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
        public CloseCommand CloseCmd { get; set; }

        public CustomCommand OpenCmd { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            CloseCmd = new CloseCommand();

            OpenCmd = new CustomCommand
                (
                    p => (p as Window).Width < 150,
                    p => new MainWindow().Show()
                );

            this.DataContext = this;
        }
    }
}
