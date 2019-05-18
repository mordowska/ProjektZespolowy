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
        #region
        static string keySeed = "ZaWVWjbQhca0G7VPkY8JOgTlJ4mH6Ht4GBmaTxmMyfJzYUMT4p733b046nljDdubDrfzzlIrQXfjV86cwonf1aNxqbjMSXyPfJErrYRGVxCB3MmKPAoDBiArna4mYofdnGITqCnvrBIHNjF5VI3Qz0wQXOlOfmVNxGaM7XcpfeuHyEtVJB6qF2WsBviDT5bWvEq07KP6y5V983Mv9gNSQoEptScYkolzbpBycIA2SNtb6wW0PUEirLCWxZKYGpZrFoWCv8mOjFZ5HfMOLdjiG2rB9pAKvT7DPIIJw4faR31J1iWPchCzopdkmqkj94399V9r3BKl7Lg1ob6FTalQF9IQgJGfgSK6n7WNq6SLpLvo6g3AJKeXID3ncKwzct6NVek0QGE7t0SeBeDnpPFghtJ6WwTxoOFZ5gWPVnpiWS7OPZ8uq2nrVspLruE9g8Kb6slwlI5z1cmeLNGY9bo6NgMycSMpgEt4aJlvIkbg6NatDqyzh0bhLpYKRDyzXZn8RxZFUmqOM239xZYKNHSQhrsbiM0RGqi2zevZh01HJWbS3FEu0wK4r0A7roEsEUCyX4YRZl5rnSiYcxRLfHzQcYCaWpGcBSQ272fYPGJISD5ysehjQIcOzqlL0vBHqm89c1X0IzLbYx3Qqyo3MPbfWQCiJxQj86PiljPmm4GNFlU5sqtP1r9v7MDBugeobHSV0uBAFcG80pDuV1aw8BbIJLWMsRY8ASeHqa6BnuSoyNo9XeHDrxRcOUb3wpm6Y4q8oUBYqN3QS0ZXFoPtIC3cJPpSp7Om7sD0mfDNjrqyB24GJZTGBa5p7nM1N3YmwwQMtgRHdJShg4Jx05UTHBh4MxDSt03pzeM780kSak3RnwLoywPLKeGlBaz0YPcwJpvHO9e4yyg7pY1RBcbv5X8WMHgl4NQgRln230ykDycyPM299uqHQWjaPaDPekawJoOyxagBsR7HRuKgw6mh0mNgvgR3ShIjMKO947nNzEGh";
        #endregion
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
