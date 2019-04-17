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
        private string _name = "";
        private string _lastname = "";
        private string _index = "";
        private string _sex = "";
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

        private string _nameError = "";
        private string _lastnameError = "";
        private string _indexError = "";

        public UserViewModel(User user = null)
        {
            _name = user?.Name;
            _lastname = user?.Lastname;
            _index = user?.Index;
            _sex = user?.Sex;
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

        #region
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                NameError = !ValidateName() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateName() => Validator.EmptyField(Name);

        public string NameError
        {
            get => _nameError;
            set
            {
                _nameError = value;
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged();
                LastnameError = !ValidateLastname() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateLastname() => Validator.EmptyField(Lastname);

        public string LastnameError
        {
            get => _lastnameError;
            set
            {
                _lastnameError = value;
                OnPropertyChanged();
            }
        }

        public string Index
        {
            get => _index;
            set
            {
                _index = value;
                OnPropertyChanged();
                IndexError = !ValidateIndex() ? "Wpisz poprawny indeks" : "";
            }
        }

        private bool ValidateIndex() => Validator.IndexVal(Index);

        public string IndexError
        {
            get => _indexError;
            set
            {
                _indexError = value;
                OnPropertyChanged();
            }
        }

        private bool Validate()
        {
            return ValidateName() && ValidateLastname() && ValidateIndex();
        }

        #endregion

        public ICommand SavePreferencesCommand => new Command(SavePreferences);

        private void SavePreferences()
        {
            bool valid = Validate();
            if (valid)
            {
                User user = new User
                {
                    Name = Name,
                    Lastname = Lastname,
                    Index = Index,
                    Sex = _sex,
                    Floor = _floor,
                    BedLocation = _bedLocation,
                    SleepTime = _sleepTime,
                    WakeUpTime = _wakeUpTime,
                    HotOrNot = _hotOrNot,
                    Music = _music,
                    CleanUp = _cleanUp,
                    Talkative = _talkative,
                    StudyField = _studyField,
                    Sporting = _smoking,
                    HomeBack = _homeBack,
                    Smoking = _smoking,
                    Party = _party

                };
            }
        }
    }
}
