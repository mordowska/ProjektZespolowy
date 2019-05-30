﻿using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using SystemZarzadzaniaAkademikiem.Validators;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    internal class ImportantDataViewModel : BaseViewModel
    {
        private string _index = "";
        private string _indexError = "";
        private string _lastname = "";
        private string _lastnameError = "";
        private string _name = "";
        private string _nameError = "";
        private string _sex = "";

        private readonly User user = null;
        private UserRepo userRepo;

        public ImportantDataViewModel()
        {
            _name = user?.Name;
            _lastname = user?.Lastname;
            _index = user?.Index;
            _sex = user?.Sex;
            SaveImportantDataPreferences = new Command(ExecuteSaveImportantDataPreferences);
        }

        public Command SaveImportantDataPreferences { get; set; }

        private async void ExecuteSaveImportantDataPreferences()
        {
            userRepo.SaveUserAsync(user);
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

        private bool ValidateName()
        {
            return Validator.EmptyField(Name);
        }

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

        private bool ValidateLastname()
        {
            return Validator.EmptyField(Lastname);
        }

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

        private bool ValidateIndex()
        {
            return Validator.IndexVal(Index);
        }

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
    }
}