using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SystemZarzadzaniaAkademikiem.Models;
using SystemZarzadzaniaAkademikiem.Services;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class TableDetailViewModel
    {
        public string name;
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
                            //Debug.WriteLine((int)id);
                            if (App.Database.Database.Table<User>().Where(i => i.Id == (int)id).FirstOrDefaultAsync().Result!=null)
                            {
                                var user = App.Database.Database.Table<User>().Where(i => i.Id == (int)id).FirstOrDefaultAsync().Result;
                                //Debug.WriteLine(user.Name);
                               // Debug.WriteLine(user.RoomNumber);
                                if (roomRepo.GetRoomAsync(user.RoomNumber).Result != null)
                                {
                                    var room = roomRepo.GetRoomAsync(user.RoomNumber).Result;
                                    Debug.WriteLine(room.StudentA);
                                    Debug.WriteLine(room.StudentB);
                                    Debug.WriteLine(user.Index);
                                    if (room.StudentA == user.Index)
                                    {
                                        room.StudentA = null;
                                        if(userRepo.GetUserAsync(room.StudentB).Result != null)
                                        {
                                            userRepo.GetUserAsync(room.StudentB).Result.RoomMate = false;
                                        }
                                    }
                                    else if (room.StudentB == user.Index)
                                    {
                                        room.StudentB = null;
                                        if (userRepo.GetUserAsync(room.StudentA).Result != null)
                                        {
                                            userRepo.GetUserAsync(room.StudentA).Result.RoomMate = false;
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
                                        userRepo.GetUserAsync(room.StudentA).Result.RoomMate = false;
                                        userRepo.GetUserAsync(room.StudentA).Result.RoomNumber = 0;
                                    }
                                }
                                if (room.StudentB!=null)
                                {
                                    if (userRepo.GetUserAsync(room.StudentB).Result != null)
                                    {
                                        userRepo.GetUserAsync(room.StudentB).Result.RoomMate = false;
                                        userRepo.GetUserAsync(room.StudentB).Result.RoomNumber = 0;
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
