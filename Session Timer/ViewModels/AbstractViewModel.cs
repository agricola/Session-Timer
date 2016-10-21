using Prism.Mvvm;
using Session_Timer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Session_Timer.ViewModels {
    public abstract class AbstractViewModel : BindableBase {

        protected static ApplicationSettings settings;
        //protected static ObservableCollection<TimerProfile> profiles;

        public AbstractViewModel(ApplicationSettings appSettings) {
            settings = appSettings;
            Profiles = settings.Profiles;
        }

        public AbstractViewModel() {    //how to deal with this global shit
            if (Properties.Settings.Default.ApplicationSettings == null) {
                settings = new ApplicationSettings();
                Properties.Settings.Default.ApplicationSettings = settings;
                Profiles = settings.Profiles;
            } else {
                settings = Properties.Settings.Default.ApplicationSettings;
                Profiles = settings.Profiles;
            }
        }

        public ObservableCollection<TimerProfile> Profiles { get; set; }
       /*     get { return profiles; }
            set { profiles = value;}
        }*/
        /*
        protected void SetSettingsAndProfiles(List<TimerProfile> value) {
            SetProperty(ref profiles, value);
            settings.Profiles = profiles;
            profiles = value;
        }*/
/*
        public void AddProfile(TimerProfile profile) {
            profiles.Add(profile);
            SetSettingsAndProfiles(profiles);
        }

        public void RemoveProfile(TimerProfile profile) {
            profiles.Add(profile);
            SetSettingsAndProfiles(profiles);
        }*/
    }
}
