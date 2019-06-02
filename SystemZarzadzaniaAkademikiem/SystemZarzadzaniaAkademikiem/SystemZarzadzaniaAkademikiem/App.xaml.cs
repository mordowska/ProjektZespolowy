using System;
using SystemZarzadzaniaAkademikiem.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SystemZarzadzaniaAkademikiem.Data;
using System.IO;
using SystemZarzadzaniaAkademikiem.Models;
using System.Collections.Generic;
using SystemZarzadzaniaAkademikiem.Services;
using SystemZarzadzaniaAkademikiem.Enums;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SystemZarzadzaniaAkademikiem
{
    public partial class App : Application
    {
        static AppDatabase database;
        private UserRepo userRepo;
        private RoomRepo roomRepo;
        public static AppDatabase Database
        {
            get
            {
                if (database == null)
                {
                    var dbFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db3");
                    database = new AppDatabase( dbFilePath);
                }
                return database;
            }
        }
        public App()
        {
            MainPage = new NavigationPage( new MainPage());
        }

        protected override void OnStart()
        {
            userRepo = new UserRepo(Database);
            roomRepo = new RoomRepo(Database);
            if (Database.Database.Table<User>().FirstOrDefaultAsync().Result == null)
            {
                LoadCSVUsers();
                
            }
            if (Database.Database.Table<Room>().FirstOrDefaultAsync().Result == null)
            {
                LoadCSVRooms();
            }

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        private void LoadCSVUsers()
        {
            var csvFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.csv");
            using (var reader = new StreamReader(csvFilePath))
            {
                bool noColumnName = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (noColumnName)
                    {
                        noColumnName = false;
                    }
                    else
                    {
                        userRepo.SaveUserAsync(new User { Index=values[0],Name=values[1],Lastname=values[2]});
                    }
                }
            }
        }

        private void LoadCSVRooms()
        {
            var csvFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "rooms.csv");
            using (var reader = new StreamReader(csvFilePath))
            {
                bool noColumnName = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (noColumnName)
                    {
                        noColumnName = false;
                    }
                    else
                    {
                        int.TryParse(values[0], out int result);
                        Enum.TryParse(values[1], out Floor floor);
                        roomRepo.SaveRoomAsync(new Room { RoomNumber = result, Floor = floor});
                    }
                }
            }
        }
    }
}
