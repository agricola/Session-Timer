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

namespace Session_Timer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Pause(object sender, RoutedEventArgs e)
        {
            TimerLabel.Content = "Pause Pressed.";
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            TimerLabel.Content = "Start Pressed.";
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            TimerLabel.Content = "Reset Pressed.";
        }
    }
}
