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
            if (seconds < 0 || minutes < 0) throw new ArgumentException();

            int correctSeconds = seconds;
            int correctMinutes = minutes;

            if (correctSeconds > 59 || correctSeconds < 0 || correctMinutes < 0) {
                ReformatMinutesAndSeconds(correctSeconds, correctMinutes, out correctSeconds, out correctMinutes);
            }

            this.currentSeconds = correctSeconds;
            this.originalSeconds = correctSeconds;

            this.currentMinutes = correctMinutes;
            this.originalMinutes = correctMinutes;
    }
        
        public string TimeDisplay {
            get {
                string minutesDispaly = currentMinutes.ToString("00");
                string secondsDispaly = currentSeconds.ToString("00");
                return String.Format("{0}:{1}", minutesDispaly, secondsDispaly);
            }
        }

        private void ReformatMinutesAndSeconds(int seconds, int minutes, out int reformattedSeconds, out int reformattedMinutes) {
            // makes sure seconds is always inclusively between 0 and 59
            reformattedMinutes = minutes;
            reformattedSeconds = seconds;

            if (seconds > 59) {
                int extraMinutes = (seconds / 60);
                reformattedMinutes += extraMinutes;

                int extraSeconds = seconds % 60;
                reformattedSeconds = extraSeconds;
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

        public void ResetTime() {
            currentSeconds = originalSeconds;
            currentMinutes = originalMinutes;
        }

        public void CountdownOneSecond() {
            currentSeconds -= 1;
            ReformatMinutesAndSeconds(currentSeconds, currentMinutes, out currentSeconds, out currentMinutes);
        }

        public void CountUpOneSecond() {
            currentSeconds += 1;
            ReformatMinutesAndSeconds(currentSeconds, currentMinutes, out currentSeconds, out currentMinutes);
        }

        public bool IsTimerFinished() {
            bool finished = false;

            if (currentSeconds == 0 && currentMinutes == 0) finished = true;

            return finished;
        }

    }
}
