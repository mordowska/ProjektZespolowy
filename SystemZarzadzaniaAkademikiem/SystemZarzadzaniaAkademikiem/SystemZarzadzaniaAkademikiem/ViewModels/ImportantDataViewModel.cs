using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Validators;
using Xamarin.Forms;
namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    class ImportantDataViewModel : BaseViewModel
    {
        private string _name = "";
        private string _lastname = "";
        private string _index = "";
        private string _sex = "";

        private string _nameError = "";
        private string _lastnameError = "";
        private string _indexError = "";
        public ImportantDataViewModel(User user=null)
        {
            _name = user?.Name;
            _lastname = user?.Lastname;
            _index = user?.Index;
            _sex = user?.Sex;
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
        public ICommand SaveImportantDataPreferencesCommand => new Command(SaveImportantDataPreferences);
        private void SaveImportantDataPreferences()
        {
            bool valid = Validate();
            if (valid)
            {
                User user = new User
                {
                    Name = Name,
                    Lastname = Lastname,
                    Index = Index,
                    Sex = _sex
                };
            }
        }
    }
}
