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
using System.Windows.Shapes;

namespace Session_Timer
{
    /// <summary>
    /// Interaction logic for Profiles.xaml
    /// </summary>
    public partial class Profiles : Window
    {
        public Profiles()
        {
            InitializeComponent();
            LoadProfiles();
        }

        private void LoadProfiles() {
            foreach (TimerProfile profile in Session_Timer.Properties.Settings.Default.ListOfProfiles) {
                if (IsDuplicateName(profile.Name)) continue;
                else ProfileList.Items.Add(profile.Name);
            }
            ((MainWindow)Application.Current.MainWindow).RefreshComboBox(); //remove this in future (MVVM)
        }

        private void AddProfile(object sender, RoutedEventArgs e) {
            Debug.WriteLine("ADD PROFILE");
            string name = ProfileName.Text;
            if (IsDuplicateName(name)) return;
            TimerTime time = new TimerTime(ProfileTime.Text);
            TimerProfile profile = new TimerProfile(name, time, ProfileLogLocation.Text);
            App.AddProfile(profile);
            ProfileList.Items.Add(profile.Name);
            ((MainWindow)Application.Current.MainWindow).RefreshComboBox();
        }

        private void RemoveProfile(object sender, RoutedEventArgs e) {
            Debug.WriteLine("REMOVE PROFILE");
            ProfileList.Items.Remove(ProfileList.SelectedItem);
            ((MainWindow)Application.Current.MainWindow).RefreshComboBox();
        }

        private bool IsDuplicateName(string name) {
            foreach (string item in ProfileList.Items) {
                if (item == name) {
                    WarnOfDuplicate();
                    return true;
                }
            }
            return false;
        }

        private void WarnOfDuplicate() {
            //in the future make popup warning
            Debug.WriteLine("NO DUPES");
        }
    }
}
