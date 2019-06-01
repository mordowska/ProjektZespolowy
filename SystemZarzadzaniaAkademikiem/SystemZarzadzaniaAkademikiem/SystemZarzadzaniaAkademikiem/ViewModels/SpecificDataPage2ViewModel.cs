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

        public SpecificDataPage2ViewModel(string index)
        {
            user = new User();
            Talkative = user?.Talkative;
            StudyField = user?.StudyField;
            Sporting = user?.Sporting;
            HomeBack = user?.HomeBack;
            Smoking = user?.Smoking;
            Party = user?.Party;
            this.index = index;
            SaveSpecificData2 = new Command(ExecuteSaveSpecificData2);
            userRepo = new UserRepo(App.Database);
        }

        public string HomeBack { get; set; } = "";
        public string Party { get; set; } = "";
        public string Smoking { get; set; } = "";
        public string Sporting { get; set; } = "";
        public string StudyField { get; set; } = "";
        public string Talkative { get; set; } = "";

        public Command SaveSpecificData2 { get; set; }

        private async void ExecuteSaveSpecificData2()
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
}