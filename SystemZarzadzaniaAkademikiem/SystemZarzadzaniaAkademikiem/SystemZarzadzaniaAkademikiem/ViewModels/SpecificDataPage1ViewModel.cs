using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    internal class SpecificDataPage1ViewModel : BaseViewModel
    {
        private readonly UserRepo userRepo;
        public string BedLocation;
        public string CleanUp;
        public string Floor;
        public string HotOrNot;
        public string Music;
        public string SleepTime;
        public string WakeUpTime;

        public SpecificDataPage1ViewModel(User user = null)
        {
            Floor = user?.Floor;
            BedLocation = user?.BedLocation;
            CleanUp = user?.CleanUp;
            HotOrNot = user?.HotOrNot;
            Music = user?.Music;
            SleepTime = user?.SleepTime;

            SaveSpecificData1 = new Command(ExecuteSaveSpecificData1);
            userRepo = new UserRepo(App.Database);
        }

        public Command SaveSpecificData1 { get; set; }

        private async void ExecuteSaveSpecificData1()
        {
            var user = userRepo.GetUserAsync()
            {
                user.Floor = Floor,
                BedLocation = BedLocation,
                SleepTime = SleepTime,
                WakeUpTime = WakeUpTime,
                HotOrNot = HotOrNot,
                Music = Music,
                CleanUp = CleanUp
            };
            await userRepo.SaveUserAsync(user);
        }
    }
}