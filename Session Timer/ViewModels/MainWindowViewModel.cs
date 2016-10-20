using System;
using System.Collections.Generic;
using Session_Timer.Models;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Data;

namespace Session_Timer.ViewModels {
    public class MainWindowViewModel : AbstractViewModel {

        //private TimerTime currentTimer;
        private TimerProfile currentProfile;
        private DispatcherTimer dispatcherTimer;
        private string timeDisplay;

        public TimerProfile SelectedProfile {
            get { return currentProfile; }
            set {
                Pause();
                SetProperty(ref currentProfile, value);
                DisplayCurrentTime();
            }
        }
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
            dispatcherTimer = SetupDispatcherTimer();
            TimerTime currentTimer = new TimerTime(30, 0);
            SelectedProfile = new TimerProfile("Test", currentTimer); //in future currentTimer should come from the profile
            //Debug.WriteLine(SelectedProfile);
            //Debug.WriteLine(Profiles);
            Profiles.Add(SelectedProfile);
            Profiles.Add(new TimerProfile("Test1", new TimerTime(45, 0)));
            

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
            if (!SelectedProfile.TimerTime.IsTimerFinished()) {
                CountdownOneSecondOnTimer();
                DisplayCurrentTime();
            } else {
                CompleteTimer();
            }

        }

        private void CountdownOneSecondOnTimer() {
            //lowers the timer by one second
            SelectedProfile.TimerTime.CountdownOneSecond();
        }

        private void DisplayCurrentTime() {
            //updates timer to current time
            TimeDisplay = SelectedProfile.TimerTime.TimeDisplay;
        }

        private void CompleteTimer() {
            TimeDisplay = "TIMER FINISHED";
            //Debug.WriteLine("TIMER FINISHED");
            SelectedProfile.TimerTime.ResetTime();
            dispatcherTimer.Stop();
        }

        private void Pause() {
            Debug.WriteLine("pause");
            if (dispatcherTimer != null) dispatcherTimer.Stop();
        }

        private void Start() {
            Debug.WriteLine("start");
            dispatcherTimer.Start();
        }

        private void Reset() {
            Debug.WriteLine("reset");
            dispatcherTimer.Stop();
            SelectedProfile.TimerTime.ResetTime();
            DisplayCurrentTime();
        }
        /*
        private List<string> ListOfProfileNames() {
            List<string> profileNames = new List<string>();
            foreach (var profile in Session_Timer.Properties.Settings.Default.ListOfProfiles) {
                profileNames.Add(profile.Name);
            }
            return profileNames;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e) {
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
