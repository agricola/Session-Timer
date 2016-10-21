using Session_Timer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_Timer {
    public class ApplicationSettings {
        public ObservableCollection<TimerProfile> Profiles { get; set; } = new ObservableCollection<TimerProfile>();
    }
}
