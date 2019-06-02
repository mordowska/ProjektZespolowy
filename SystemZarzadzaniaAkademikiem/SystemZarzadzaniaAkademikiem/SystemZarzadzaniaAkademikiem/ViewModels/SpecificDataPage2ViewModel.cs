using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using SystemZarzadzaniaAkademikiem.Validators;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class SpecificDataPage2ViewModel : BaseViewModel
    {
        public readonly string index;
        private readonly User user;
        private readonly UserRepo userRepo;
        public bool isValid = false;
        private string _homeBack = "";
        private string _bedLocationError = "";
        private string _party = "";
        private string _partyError = "";
        private string _smoking = "";
        private string _smokingError = "";
        private string _sporting = "";
        private string _sportingError = "";
        private string _studyField = "";
        private string _studyFieldError = "";
        private string _talkative = "";
        private string _talkativeError = "";


        public SpecificDataPage2ViewModel(string index)
        {
            user = new User();
            this.index = index;
            SaveSpecificData2 = new Command(ExecuteSaveSpecificData2);
            userRepo = new UserRepo(App.Database);
        }

        public Command SaveSpecificData2 { get; set; }

        private async void ExecuteSaveSpecificData2()
        {
            isValid = Validate();
            if (isValid)
            {
                var user = userRepo.GetUserAsync(index).Result;
                user.Talkative = Talkative;
                user.StudyField = StudyField;
                user.Sporting = Sporting;
                user.HomeBack = HomeBack;
                user.Smoking = Smoking;
                user.Party = Party;
                await userRepo.SaveUserAsync(user);
            }
        }

        public bool Validate()
        {
            return ValidateHomeBack() && ValidateTalkative() && ValidateSporting() && ValidateStudyField() &&
                ValidateParty() && ValidateSmoking();
        }
        #region
        public string HomeBack
        {
            get => _homeBack;
            set
            {
                _homeBack = value;
                OnPropertyChanged();
                HomeBackError = !ValidateHomeBack() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateHomeBack()
        {
            return Validator.EmptyField(HomeBack);
        }

        public string HomeBackError
        {
            get => _bedLocationError;
            set
            {
                _bedLocationError = value;
                OnPropertyChanged();
            }
        }

        public string Talkative
        {
            get => _talkative;
            set
            {
                _talkative = value;
                OnPropertyChanged();
                TalkativeError = !ValidateTalkative() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateTalkative()
        {
            return Validator.EmptyField(Talkative);
        }

        public string TalkativeError
        {
            get => _talkativeError;
            set
            {
                _talkativeError = value;
                OnPropertyChanged();
            }
        }

       public string Sporting
        {
            get => _sporting;
            set
            {
                _sporting = value;
                OnPropertyChanged();
                SportingError = !ValidateSporting() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateSporting()
        {
            return Validator.EmptyField(Sporting);
        }

        public string SportingError
        {
            get => _sportingError;
            set
            {
                _sportingError = value;
                OnPropertyChanged();
            }
        }

        public string StudyField
        {
            get => _studyField;
            set
            {
                _studyField = value;
                OnPropertyChanged();
                StudyFieldError = !ValidateStudyField() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateStudyField()
        {
            return Validator.EmptyField(StudyField);
        }

        public string StudyFieldError
        {
            get => _studyFieldError;
            set
            {
                _studyFieldError = value;
                OnPropertyChanged();
            }
        }
        public string Party
        {
            get => _party;
            set
            {
                _party = value;
                OnPropertyChanged();
                PartyError = !ValidateParty() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateParty()
        {
            return Validator.EmptyField(Party);
        }

        public string PartyError
        {
            get => _partyError;
            set
            {
                _partyError = value;
                OnPropertyChanged();
            }
        }
        public string Smoking
        {
            get => _smoking;
            set
            {
                _smoking = value;
                OnPropertyChanged();
                SmokingError = !ValidateSmoking() ? "Pole nie może być puste" : "";
            }
        }

        private bool ValidateSmoking()
        {
            return Validator.EmptyField(Smoking);
        }

        public string SmokingError
        {
            get => _smokingError;
            set
            {
                _smokingError = value;
                OnPropertyChanged();
            }
        }


        #endregion
    }
}