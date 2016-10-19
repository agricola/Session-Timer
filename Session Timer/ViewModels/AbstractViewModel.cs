using Prism.Mvvm;
using Session_Timer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Session_Timer.ViewModels {
    public abstract class AbstractViewModel : BindableBase {

        protected static ApplicationSettings settings;
        protected static List<TimerProfile> profiles;

        public AbstractViewModel(ApplicationSettings appSettings) {
            settings = appSettings;
            profiles = settings.Profiles;
        }

        public AbstractViewModel() {
        }

        public List<TimerProfile> Profiles {
            get { return profiles; }
            set { SetSettingsAndProfiles(value); }
        }

        protected void SetSettingsAndProfiles(List<TimerProfile> value) {
            SetProperty(ref profiles, value);
            settings.Profiles = profiles;
        }

        public void AddProfile(TimerProfile profile) {
            profiles.Add(profile);
            SetSettingsAndProfiles(profiles);
        }

        public void RemoveProfile(TimerProfile profile) {
            profiles.Add(profile);
            SetSettingsAndProfiles(profiles);
        }
    }
}
