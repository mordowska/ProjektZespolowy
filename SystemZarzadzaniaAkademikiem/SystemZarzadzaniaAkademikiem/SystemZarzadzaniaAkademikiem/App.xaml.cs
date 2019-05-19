using System;
using SystemZarzadzaniaAkademikiem.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SystemZarzadzaniaAkademikiem.Data;
using System.IO;
using SQLite.Net.Cipher.Security;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SystemZarzadzaniaAkademikiem
{
    public partial class App : Application
    {
        static AppDatabase database;
        public static AppDatabase Database
        {
            get
            {
                if (database == null)
                {
                    var dbFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db3");
                    var platform = new SQLite.Net.Platform.Generic.SQLitePlatformGeneric();
                    var someSalt = CryptoService.GenerateRandomKey(16);
                    database = new AppDatabase(platform,dbFilePath,someSalt);
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
            
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
