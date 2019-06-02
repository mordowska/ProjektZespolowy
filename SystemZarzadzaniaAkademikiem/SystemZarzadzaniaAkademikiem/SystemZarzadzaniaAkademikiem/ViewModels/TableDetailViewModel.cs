using System.Diagnostics;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class TableDetailViewModel
    {
        private string name;
        private UserRepo userRepo;
        private RoomRepo roomRepo;
        public TableDetailViewModel(string name)
        {
            this.name = name;
            userRepo = new UserRepo(App.Database);
            roomRepo = new RoomRepo(App.Database);
        }
        public Command DeleteRecordCommand
        {
            get
            {
                return new Command((id) =>
                {
                    switch (name)
                    {
                        case "SuperUser":
                            App.Database.DatabaseNotAsync.Execute("DELETE FROM " + name + " WHERe Id=" + id);
                            break;
                        case "User":
                            if (App.Database.Database.Table<User>().Where(i => i.Id == (int)id).FirstOrDefaultAsync().Result!=null)
                            {
                                var user = App.Database.Database.Table<User>().Where(i => i.Id == (int)id).FirstOrDefaultAsync().Result;
                                if (roomRepo.GetRoomAsync(user.RoomNumber).Result != null)
                                {
                                    var room = roomRepo.GetRoomAsync(user.RoomNumber).Result;
                                    if (room.StudentA == user.Index)
                                    {
                                        room.StudentA = null;
                                        roomRepo.SaveRoomAsync(room);
                                        if(userRepo.GetUserAsync(room.StudentB).Result != null)
                                        {
                                            var roommate = userRepo.GetUserAsync(room.StudentB).Result;
                                            roommate.RoomMate = false;
                                            userRepo.SaveUserAsync(roommate);
                                        }
                                    }
                                    else if (room.StudentB == user.Index)
                                    {
                                        room.StudentB = null;
                                        roomRepo.SaveRoomAsync(room);
                                        if (userRepo.GetUserAsync(room.StudentA).Result != null)
                                        {
                                            var roommate = userRepo.GetUserAsync(room.StudentB).Result;
                                            roommate.RoomMate = false;
                                            userRepo.SaveUserAsync(roommate);
                                        }
                                    }
                                }
                                userRepo.DeleteUserAsync(user);
                            }
                            break;
                        case "Room":
                            if (App.Database.Database.Table<Room>().Where(i => i.Id == (int)id).FirstOrDefaultAsync().Result != null)
                            {
                                var room = App.Database.Database.Table<Room>().Where(i => i.Id == (int)id).FirstOrDefaultAsync().Result;
                                if (room.StudentA!=null)
                                {
                                    if (userRepo.GetUserAsync(room.StudentA).Result!=null)
                                    {
                                        var roommate = userRepo.GetUserAsync(room.StudentA).Result;
                                        roommate.RoomMate = false;
                                        roommate.RoomNumber = 0;
                                        userRepo.SaveUserAsync(roommate);
                                    }
                                }
                                if (room.StudentB!=null)
                                {
                                    if (userRepo.GetUserAsync(room.StudentB).Result != null)
                                    {
                                        var roommate = userRepo.GetUserAsync(room.StudentB).Result;
                                        roommate.RoomMate = false;
                                        roommate.RoomNumber = 0;
                                        userRepo.SaveUserAsync(roommate);
                                    }
                                }
                                roomRepo.DeleteRoomAsync(room);
                            }
                            break;
                        default:
                            Debug.WriteLine("ERROR, Unkown table");
                            break;
                    }
                    

                });
            }
        }
    }
}
