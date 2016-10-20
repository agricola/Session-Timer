using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session_Timer.Models;
using System.Diagnostics;

namespace Session_Timer.ViewModels
{
    public class ProfilesWindowViewModel : AbstractViewModel
    {

        private string name;
        private string time;
        private TimerProfile selectedProfile;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        public string Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }
        public TimerProfile SelectedProfile
        {
            get { return selectedProfile; }
            set
            {
                SetProperty(ref selectedProfile, value);
            }
        }
        public Command AddProfileCommand { get; private set; }
        public Command RemoveProfileCommand { get; private set; }

        public ProfilesWindowViewModel()
        {
            AddProfileCommand = new Command(AddProfile);
            RemoveProfileCommand = new Command(RemoveProfile);
        }

        public void AddProfile()
        {
            //Debug.WriteLine(Profiles.Count);
            TimerProfile newProfile = new TimerProfile(name, new TimerTime(time));
            Profiles.Add(newProfile);
            Name = "";
            Time = "";
            //Profiles = Profiles;
            //Debug.WriteLine(Profiles.Count);
        }

        public void RemoveProfile()
        {
            if (Profiles.Count == 1) return;    //in future give popup to tell the person they can't remove the last entry
            else Profiles.Remove(SelectedProfile);
            //Profiles = Profiles;
            //Debug.WriteLine(Profiles.Count);
        }
    }
}
