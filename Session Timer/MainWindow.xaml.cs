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

        TimerTime currentTimer;

        public MainWindow() {
            InitializeComponent();
            currentTimer = NewTimer(2, 1); //makes a timer at 1 min 2 seconds (doesn't countdown auto)
        }

        private void CountdownOneSecondOnTimer() {
            //lowers the timer by one second
            currentTimer.CountdownOneSecond();
        }

        private string TimerDisplay() {
            //gets current timer's display in string format
            return currentTimer.TimeDisplay;
        }

        private TimerTime NewTimer(int seconds, int minutes) {
            //creates a new instance of TimerTime
            TimerTime newTimer;
            newTimer = new TimerTime(seconds, minutes);
            return newTimer;
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
