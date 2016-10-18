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
    /// 
    public partial class App : Application {

        //private static List<TimerProfile> timerProfiles;

        public App() {
            LoadProfiles();
        }

        ~App() {
            SaveProfiles();
        }

        private void LoadProfiles() {
            Debug.WriteLine("LOAD");
            Session_Timer.Properties.Settings.Default.ListOfProfiles = new List<TimerProfile>();
            //timerProfiles = Session_Timer.Properties.Settings.Default.ListOfProfiles;
            //Session_Timer.Properties.Settings.Default.ListOfProfiles.Add(new TimerProfile("TEST", new TimerTime(30, 1), "blah"));
        }

        private void SaveProfiles() {
            /*Session_Timer.Properties.Settings.Default.Reset();
            
            foreach (TimerProfile profile in timerProfiles) {
                Session_Timer.Properties.Settings.Default.ListOfProfiles.Add(profile);
            }*/

            Session_Timer.Properties.Settings.Default.Save();
        }

        public static void RemoveProfile(TimerProfile profile) {
            //timerProfiles.Remove(profile);
            Session_Timer.Properties.Settings.Default.ListOfProfiles.Remove(profile);
        }

        public static void AddProfile(TimerProfile profile) {
            //timerProfiles.Add(profile);
            Session_Timer.Properties.Settings.Default.ListOfProfiles.Add(profile);
        }
    }
}
