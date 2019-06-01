using System;
using SystemZarzadzaniaAkademikiem.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SystemZarzadzaniaAkademikiem.Data;
using System.IO;
using System.Diagnostics;
using SystemZarzadzaniaAkademikiem.Models;
using System.Collections.Generic;
using SystemZarzadzaniaAkademikiem.Services;
using System.Security.Cryptography;
using System.Text;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SystemZarzadzaniaAkademikiem
{
    public partial class App : Application
    {
        static AppDatabase database;
        private UserRepo userRepo;
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
            if (Database.Database.Table<User>().FirstOrDefaultAsync().Result == null)
            {
                LoadCSVUsers();
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
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
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
    }
}
