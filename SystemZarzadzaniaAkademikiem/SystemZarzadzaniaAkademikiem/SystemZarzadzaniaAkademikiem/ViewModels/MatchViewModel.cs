using System.Collections.Generic;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class MatchViewModel : BaseViewModel
    {
        private const int maxPoints = 12;
        public readonly string index;
        private readonly RoomRepo roomRepo;
        private readonly User user;
        private readonly UserRepo userRepo;
        private List<Room> _rooms;
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

        public List<Room> Rooms
        {
            get => _rooms;
            set
            {
                _rooms = roomRepo.GetRoomsAsync().Result;
                _rooms = value;
                OnPropertyChanged();
            }
        }

        public void SavePoints(List<User> users = null)
        {
            points = 0;
            foreach (var usr in users ?? Users)
                if (usr.Index != index && usr.Sex == user.Sex && usr.RoomMate == false)
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

        public Room FindFreeRoom()
        {
            foreach (var room in Rooms)
                if (room.StudentA == null && room.StudentB == null)
                    return room;
            return null;
        }

        public bool RoomHasFreeSlot(Room room)
        {
            if (room.StudentA == null || room.StudentB == null)
                return true;
            return false;
        }

        public void ContactWithAdmin()
        {
            //koniec programu skontaktuj sie z adminem
        }

        public void Accomodate(Room room)
        {
            var user = userRepo.GetUserAsync(bestCandidate).Result;
            if (room.StudentA == null) room.StudentA = this.user.Index;
            room.StudentB = this.user.Index;
            user.RoomMate = true;
            this.user.RoomMate = true;
        }


        public void DecideWhatToDo()
        {
            User user = null;
            if (points >= 9)
            {
                user = userRepo.GetUserAsync(bestCandidate).Result;
                var room = roomRepo.GetRoomAsync(user.RoomNumber).Result;
                if (room.StudentA != null && room.StudentB != null)
                    ContactWithAdmin();
                else
                    Accomodate(room);
            }
            else
            {
                var room = FindFreeRoom();
                if (room == null)
                {
                    var roomBestCandidate = roomRepo.GetRoomAsync(user.RoomNumber).Result;
                    if (RoomHasFreeSlot(roomBestCandidate))
                        Accomodate(roomBestCandidate);
                    else
                        ContactWithAdmin();
                }
                else if (room != null)
                {
                    room.StudentA = this.user.Index;
                }
            }
        }
    }
}