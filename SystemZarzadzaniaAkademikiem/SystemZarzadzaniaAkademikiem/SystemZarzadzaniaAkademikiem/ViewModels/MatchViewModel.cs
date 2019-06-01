using System.Collections.Generic;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class MatchViewModel : BaseViewModel
    {
        public readonly string index;
        private readonly User user;
        private readonly UserRepo userRepo;
        private List<User> _users;
        private string bestCandidate = "";
        private int points;

        public MatchViewModel(string index)
        {
            this.index = index;
            userRepo = new UserRepo(App.Database);
            user = userRepo.GetUserAsync(index).Result;
        }

        public List<User> Users
        {
            get => _users;
            set
            {
                _users = userRepo.GetUsersAsync().Result;
                _users = value;
                OnPropertyChanged();
            }
        }

        public void SavePoints()
        {
            foreach (var usr in Users)
                if (usr.Index != index && usr.Sex == user.Sex)
                    CountPoints(usr);
        }

        public void CountPoints(User user)
        {
            var points = 0;
            if (user.Floor == this.user.Floor) points++;
            else if (user.BedLocation == this.user.BedLocation) points++;
            else if (user.SleepTime == this.user.SleepTime) points++;
            else if (user.WakeUpTime == this.user.WakeUpTime) points++;
            else if (user.HotOrNot == this.user.HotOrNot) points++;
            else if (user.Music == this.user.Music) points++;
            else if (user.CleanUp == this.user.CleanUp) points++;
            else if (user.Talkative == this.user.Talkative) points++;
            else if (user.StudyField == this.user.StudyField) points++;
            else if (user.Sporting == this.user.Sporting) points++;
            else if (user.HomeBack == this.user.HomeBack) points++;
            else if (user.Smoking == this.user.Smoking) points++;
            else if (user.Party == this.user.Party) points++;

            if (points > this.points)
            {
                this.points = points;
                bestCandidate = user.Index;
            }
        }
    }
}