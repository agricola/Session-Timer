using System;
using System.Collections.Generic;
using Session_Timer.Models;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Input;

namespace Session_Timer.ViewModels {
    public class MainWindowViewModel : AbstractViewModel {

        private TimerTime currentTimer;
        private TimerProfile currentProfile;
        private DispatcherTimer dispatcherTimer;
        private string timeDisplay;

        public string SelectedProfileName { get { return currentProfile.Name; } }
        public string TimeDisplay {
            get { return timeDisplay; }
            set { SetProperty(ref timeDisplay, value); }
        }
        public Command StartCommand { get; private set; }
        public Command PauseCommand { get; private set; }
        public Command ResetCommand { get; private set; }
        //public Command ComboBoxLoadCommand { get; private set; }
        //public Command ComboBoxChangeCommand { get; private set; }
        public Command ProfileSettingsCommand { get; private set; }

        public MainWindowViewModel() : base() {
            Debug.WriteLine(settings);
            currentTimer = NewTimer(30, 0);
            currentProfile = new TimerProfile("Test", currentTimer); //in future currentTimer should come from the profile
            dispatcherTimer = SetupDispatcherTimer();

            StartCommand = new Command(Start);
            PauseCommand = new Command(Pause);
            ResetCommand = new Command(Reset);
            ProfileSettingsCommand = new Command(ProfilesSettingsButton_Click);

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
            TimeDisplay = currentTimer.TimeDisplay;
        }

        private TimerTime NewTimer(int seconds, int minutes) {
            //creates a new instance of TimerTime
            TimerTime newTimer;
            newTimer = new TimerTime(seconds, minutes);
            return newTimer;
        }

        private void CompleteTimer() {
            TimeDisplay = "TIMER FINISHED";
            //Debug.WriteLine("TIMER FINISHED");
            currentTimer.ResetTime();
            dispatcherTimer.Stop();
        }

        private void Pause() {
            Debug.WriteLine("pause");
            dispatcherTimer.Stop();
        }

        private void Start() {
            Debug.WriteLine("start");
            dispatcherTimer.Start();
        }

        private void Reset() {
            Debug.WriteLine("reset");
            dispatcherTimer.Stop();
            currentTimer.ResetTime();
            DisplayCurrentTime();
        }

        private List<string> ListOfProfileNames() {
            List<string> profileNames = new List<string>();
            foreach (var profile in Session_Timer.Properties.Settings.Default.ListOfProfiles) {
                profileNames.Add(profile.Name);
            }
            return profileNames;
        }

        /*private void ComboBox_Loaded(object sender, RoutedEventArgs e) {
            // ... Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            // ... Assign the ItemsSource to the List.
            RefreshComboBox();

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //do stuff when changed
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
            TimerLabel.Content = "Selected: " + value;
        }*/

        private void ProfilesSettingsButton_Click() {
            Profiles OpenProfilesWindow = new Profiles();
            OpenProfilesWindow.Show();
        }
        /*
        public void RefreshComboBox() {
            comboBox.ItemsSource = ListOfProfileNames();
        }*/
    }
}
