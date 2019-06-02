using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class SpecificDataPage1ViewModel : BaseViewModel
    {
        public readonly string index;
        private readonly User user;
        private readonly UserRepo userRepo;

        public SpecificDataPage1ViewModel(string index)
        {
            user = new User();
            //Floor = user?.Floor;
            //BedLocation = user?.BedLocation;
            //CleanUp = user?.CleanUp;
            //HotOrNot = user?.HotOrNot;
            //Music = user?.Music;
            //SleepTime = user?.SleepTime;
            this.index = index;
            SaveSpecificData1 = new Command(ExecuteSaveSpecificData1);
            userRepo = new UserRepo(App.Database);
        }

        public string BedLocation { get; set; } = "Przy oknie";
        public string CleanUp { get; set; } = "Tak";
        public string Floor { get; set; } = "1";
        public string HotOrNot { get; set; } = "Cieplej";
        public string Music { get; set; } = "Słuchawki";
        public string SleepTime { get; set; } = "Przed 22.30";
        public string WakeUpTime { get; set; } = "Przed 6.00";

        public Command SaveSpecificData1 { get; set; }

        private async void ExecuteSaveSpecificData1()
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
}