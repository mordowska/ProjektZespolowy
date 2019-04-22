using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Validators;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    class UserViewModel : BaseViewModel
    {
        private string _floor = "";
        private string _bedLocation = "";
        private string _sleepTime = "";
        private string _wakeUpTime = "";
        private string _hotOrNot = "";
        private string _music = "";
        private string _cleanUp = "";
        private string _talkative = "";
        private string _studyField = "";
        private string _sporting = "";
        private string _homeBack = "";
        private string _smoking = "";
        private string _party = "";



        public UserViewModel(User user = null)
        {
            _floor = user?.Floor;
            _bedLocation = user?.BedLocation;
            _sleepTime = user?.SleepTime;
            _wakeUpTime = user?.WakeUpTime;
            _hotOrNot = user?.HotOrNot;
            _music = user?.Music;
            _cleanUp = user?.CleanUp;
            _talkative = user?.Talkative;
            _studyField = user?.StudyField;
            _sporting = user?.Sporting;
            _homeBack = user?.HomeBack;
            _smoking = user?.Smoking;
            _party = user?.Party;
        }

       


    }
}
