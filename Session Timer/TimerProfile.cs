using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_Timer {
    class TimerProfile {
        private string name;
        private TimerTime timerTime;
        private string logLocation;

        public TimerProfile(string name, TimerTime timerTime, string logLocation = "") {
            this.name = name;
            this.timerTime = timerTime;
            this.logLocation = logLocation;
        }

        private void LogSession() {

        }

        public void CompleteTimer() {
            LogSession();
        }
    }
}
