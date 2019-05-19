using System;
using SystemZarzadzaniaAkademikiem.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SystemZarzadzaniaAkademikiem.Data;
using System.IO;

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
