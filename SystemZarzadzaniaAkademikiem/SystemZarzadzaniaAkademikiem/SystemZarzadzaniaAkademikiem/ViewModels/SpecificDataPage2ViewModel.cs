using System;
using System.Collections.Generic;
using System.Text;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    internal class SpecificDataPage2ViewModel : BaseViewModel
    {
        private readonly UserRepo userRepo;
        public string Talkative;
        public string StudyField;
        public string Sporting;
        public string HomeBack;
        public string Smoking;
        public string Party;

        public SpecificDataPage2ViewModel(User user = null)
        {
            Talkative = user?.Talkative;
            StudyField = user?.StudyField;
            Sporting = user?.Sporting;
            HomeBack = user?.HomeBack;
            Smoking = user?.Smoking;
            Party = user?.Party;

            SaveSpecificData2 = new Command(ExecuteSaveSpecificData2);
            userRepo = new UserRepo(App.Database);
        }

        public Command SaveSpecificData2 { get; set; }

        private async void ExecuteSaveSpecificData2()
        {
            var user = new User
            {
                Talkative = Talkative,
                StudyField = StudyField,
                Sporting = Sporting,
                HomeBack = HomeBack,
                Smoking = Smoking,
                Party = Party
            };
            await userRepo.SaveUserAsync(user);
        }
    }
}

    

