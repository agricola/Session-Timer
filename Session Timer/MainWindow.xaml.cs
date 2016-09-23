using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace Session_Timer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        TimerTime currentTimer;
        TimerProfile currentProfile;
        DispatcherTimer dispatcherTimer;

        public MainWindow() {
            InitializeComponent();

            currentTimer = NewTimer(30, 0);
            currentProfile = new TimerProfile("Test", currentTimer); //in future currentTimer should come from the profile
            dispatcherTimer = SetupDispatcherTimer();

            DisplayCurrentTime();
        }

        private DispatcherTimer SetupDispatcherTimer() {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Tick += new EventHandler(CountdownAndDisplayOnTick);
            timer.Interval = new TimeSpan(0, 0, 1);

            return timer;
        }

        private void CountdownAndDisplayOnTick(object sender, EventArgs e) {
            //Debug.WriteLine("tick");
            if (!currentTimer.IsTimerFinished()) {
                CountdownOneSecondOnTimer();
                DisplayCurrentTime();
            } else {
                CompleteTimer();
            }

        }

        private void CountdownOneSecondOnTimer() {
            //lowers the timer by one second
            currentTimer.CountdownOneSecond();
        }

        private void DisplayCurrentTime() {
            //updates timer to current time
            TimerLabel.Content = currentTimer.TimeDisplay;
        }

        private TimerTime NewTimer(int seconds, int minutes) {
            //creates a new instance of TimerTime
            TimerTime newTimer;
            newTimer = new TimerTime(seconds, minutes);
            return newTimer;
        }

        private void CompleteTimer() {
            TimerLabel.Content = "TIMER FINISHED";
            //Debug.WriteLine("TIMER FINISHED");
            currentTimer.ResetTime();
            dispatcherTimer.Stop();
        }

        private void Pause(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("start");
            dispatcherTimer.Start();
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            currentTimer.ResetTime();
            DisplayCurrentTime();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> data = new List<string>();
            data.Add("VN");
            data.Add("pornography");
            
            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = data;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //do stuff when changed
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
            TimerLabel.Content = "Selected: " + value;
        }

        private void ProfilesSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Profiles OpenProfilesWindow = new Session_Timer.Profiles();
            OpenProfilesWindow.Show();
        }
    }
}
