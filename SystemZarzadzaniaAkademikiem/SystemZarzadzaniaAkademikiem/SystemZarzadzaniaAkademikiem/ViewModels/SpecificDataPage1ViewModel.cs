using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using SystemZarzadzaniaAkademikiem.Validators;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class SpecificDataPage1ViewModel : BaseViewModel
    {
        public readonly string index;
        private readonly User user;
        private readonly UserRepo userRepo;
        public bool isValid = false;
        private string _bedLocation = "";
        private string _bedLocationError = "";
        private string _sleepTime = "";
        private string _sleepTimeError = "";
        private string _wakeUpTime = "";
        private string _wakeUpTimeError = "";
        private string _hotOrNot = "";
        private string _hotOrNotError = "";
        private string _music = "";
        private string _musicError = "";
        private string _cleanUp = "";
        private string _cleanUpError = "";
        private string _floor = "";
        private string _floorError = "";

        public SpecificDataPage1ViewModel(string index)
        {
            user = new User();
            this.index = index;
            SaveSpecificData1 = new Command(ExecuteSaveSpecificData1);
            userRepo = new UserRepo(App.Database);
        }

        public Command SaveSpecificData1 { get; set; }

        private async void ExecuteSaveSpecificData1()
        {
            isValid = Validate();
            if (isValid)
            {
                var user = userRepo.GetUserAsync(index).Result;
                user.Floor = Floor;
                user.BedLocation = BedLocation;
                user.SleepTime = SleepTime;
                user.WakeUpTime = WakeUpTime;
                user.HotOrNot = HotOrNot;
                user.Music = Music;
                user.CleanUp = CleanUp;
                await userRepo.SaveUserAsync(user);
            }
        }

        public bool Validate()
        {
            return ValidateBedLocation() && ValidateCleanUp() && ValidateFloor() && ValidateHotOrNot() && ValidateMusic() &&
                ValidateSleepTime() && ValidateWakeUpTime();
        }
        #region
        public string BedLocation
        {
            get => _bedLocation;
            set
            {
                _bedLocation = value;
                OnPropertyChanged();
                BedLocationError = !ValidateBedLocation() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateBedLocation()
        {
            return Validator.EmptyField(BedLocation);
        }

        public string BedLocationError
        {
            get => _bedLocationError;
            set
            {
                _bedLocationError = value;
                OnPropertyChanged();
            }
        }

        public string CleanUp
        {
            get => _cleanUp;
            set
            {
                _cleanUp = value;
                OnPropertyChanged();
                CleanUpError = !ValidateCleanUp() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateCleanUp()
        {
            return Validator.EmptyField(CleanUp);
        }

        public string CleanUpError
        {
            get => _cleanUpError;
            set
            {
                _cleanUpError = value;
                OnPropertyChanged();
            }
        }

        public string Floor
        {
            get => _floor;
            set
            {
                _floor = value;
                OnPropertyChanged();
                FloorError = !ValidateFloor() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateFloor()
        {
            return Validator.EmptyField(Floor);
        }

        public string FloorError
        {
            get => _floorError;
            set
            {
                _floorError = value;
                OnPropertyChanged();
            }
        }

        public string HotOrNot
        {
            get => _hotOrNot;
            set
            {
                _hotOrNot = value;
                OnPropertyChanged();
                HotOrNotError = !ValidateHotOrNot() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateHotOrNot()
        {
            return Validator.EmptyField(HotOrNot);
        }

        public string HotOrNotError
        {
            get => _hotOrNotError;
            set
            {
                _hotOrNotError = value;
                OnPropertyChanged();
            }
        }

        public string Music
        {
            get => _music;
            set
            {
                _music = value;
                OnPropertyChanged();
                MusicError = !ValidateMusic() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateMusic()
        {
            return Validator.EmptyField(Music);
        }

        public string MusicError
        {
            get => _musicError;
            set
            {
                _musicError = value;
                OnPropertyChanged();
            }
        }
        public string SleepTime
        {
            get => _sleepTime;
            set
            {
                _sleepTime = value;
                OnPropertyChanged();
                SleepTimeError = !ValidateSleepTime() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateSleepTime()
        {
            return Validator.EmptyField(SleepTime);
        }

        public string SleepTimeError
        {
            get => _sleepTimeError;
            set
            {
                _sleepTimeError = value;
                OnPropertyChanged();
            }
        }
        public string WakeUpTime
        {
            get => _wakeUpTime;
            set
            {
                _wakeUpTime = value;
                OnPropertyChanged();
                WakeUpTimeError = !ValidateWakeUpTime() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateWakeUpTime()
        {
            return Validator.EmptyField(WakeUpTime);
        }

        public string WakeUpTimeError
        {
            get => _wakeUpTimeError;
            set
            {
                _wakeUpTimeError = value;
                OnPropertyChanged();
            }
        }


        #endregion
    }
}