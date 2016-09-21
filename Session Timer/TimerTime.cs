using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_Timer {
    class TimerTime {
        private int currentSeconds;
        private int currentMinutes;
        private int originalSeconds;
        private int originalMinutes;

        public TimerTime(int seconds, int minutes) {
            this.currentSeconds = seconds;
            this.originalSeconds = seconds;

            this.currentMinutes = minutes;
            this.originalMinutes = minutes;
    }
        
        public string TimeDisplay {
            get {
                return String.Format("{0}:{1}", currentMinutes, currentSeconds);
            }
        }

        private void ReformatMinutesAndSeconds(int seconds, int minutes, out int reformattedSeconds, out int reformattedMinutes) {
            // makes sure seconds is always inclusively between 0 and 59
            reformattedMinutes = minutes;
            reformattedSeconds = seconds;

            if (seconds > 59) {
                int extraMinutes = (seconds / 60);
                reformattedMinutes += extraMinutes;
                reformattedSeconds = 0;
            } else if (seconds < 0) {
                int extraMinutes = -(seconds / 60);
                reformattedMinutes -= (1 + extraMinutes);
                reformattedSeconds = 59;
            }

            if (reformattedMinutes < 0) {
                reformattedSeconds = 0;
                reformattedMinutes = 0;
            }
        }

        private int MinutesAndSecondsToSeconds(int seconds, int minutes) {
            int newSeconds = seconds;

            newSeconds += minutes * 60;

            return newSeconds;
        }

        private int ElapsedSeconds() {
            int elapsedSeconds = 0;

            int oldSeconds = MinutesAndSecondsToSeconds(originalSeconds, originalMinutes);
            int newSeconds = MinutesAndSecondsToSeconds(currentSeconds, currentMinutes);
            elapsedSeconds = oldSeconds - newSeconds;

            return elapsedSeconds;
        }

        public void CountdownOneSecond() {
            currentSeconds -= 1;
            ReformatMinutesAndSeconds(currentSeconds, currentMinutes, out currentSeconds, out currentMinutes);
        }

        public void CountUpOneSecond() {
            currentSeconds += 1;
            ReformatMinutesAndSeconds(currentSeconds, currentMinutes, out currentSeconds, out currentMinutes);
        }

    }
}
