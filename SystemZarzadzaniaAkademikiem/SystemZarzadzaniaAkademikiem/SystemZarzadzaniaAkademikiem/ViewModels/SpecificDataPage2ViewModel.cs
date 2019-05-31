using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class SpecificDataPage2ViewModel : BaseViewModel
    {
        private readonly UserRepo userRepo;
        public string HomeBack;
        private readonly string index;
        public string Party;
        public string Smoking;
        public string Sporting;
        public string StudyField;
        public string Talkative;
        private readonly User user;

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