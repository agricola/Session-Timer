using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_Timer {
    [Serializable]
    public class TimerProfile {
        //private string name;
        //private TimerTime timerTime;
        //private string logLocation;

        public TimerProfile() { }

        public TimerProfile(string name, TimerTime timerTime, string logLocation = "") {
            this.Name = name;
            this.TimerTime = timerTime;
            this.LogLocation = logLocation;
        }

        public string Name { get; }
        public TimerTime TimerTime { get; }
        public string LogLocation { get; }

        private void LogSession() {

        }

        public void CompleteTimer() {
            LogSession();
        }
    }
}
