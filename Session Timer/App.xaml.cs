using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Session_Timer {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        private static List<TimerProfile> timerProfiles;

        public App() {
            LoadProfiles();
        }

        ~App() {
            SaveProfiles();
        }

        private void LoadProfiles() {
            timerProfiles = new List<TimerProfile>();
            //put loading from config here in the future
        }

        private void SaveProfiles() {

        }

        public static void RemoveProfile(TimerProfile profile) {
            timerProfiles.Remove(profile);
        }

        public static void AddProfile(TimerProfile profile) {
            timerProfiles.Add(profile);
        }
    }
}
