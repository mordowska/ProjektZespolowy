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

        public string BedLocation { get; set; }
        public string CleanUp { get; set; }
        public string Floor { get; set; }
        public string HotOrNot { get; set; }
        public string Music { get; set; }
        public string SleepTime { get; set; }
        public string WakeUpTime { get; set; }

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