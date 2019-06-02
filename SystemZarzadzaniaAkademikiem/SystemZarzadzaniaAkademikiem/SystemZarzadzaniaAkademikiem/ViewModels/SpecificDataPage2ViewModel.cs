using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class SpecificDataPage2ViewModel : BaseViewModel
    {
        public readonly string index;
        private readonly User user;
        private readonly UserRepo userRepo;
        public bool isValid = false;

        public SpecificDataPage2ViewModel(string index)
        {
            user = new User();
            this.index = index;
            SaveSpecificData2 = new Command(ExecuteSaveSpecificData2);
            userRepo = new UserRepo(App.Database);
        }

        public string HomeBack { get; set; }
        public string Party { get; set; }
        public string Smoking { get; set; }
        public string Sporting { get; set; }
        public string StudyField { get; set; } 
        public string Talkative { get; set; }

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
            return false;
        }
    }
}