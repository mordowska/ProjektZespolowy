using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SystemZarzadzaniaAkademikiem.Views;
using SystemZarzadzaniaAkademikiem.Services;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    class AdminLoginViewModel : BaseViewModel
    {
        private string _login;
        private string _password;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public Command LoginAsAdmin { get; set; }
        AdminRepo adminRepo;

        public AdminLoginViewModel()
        {
            Title = "Welcome to Admin Login Page.Please enter credentials below.";
            LoginAsAdmin = new Command(ExecuteLoginAsAdmin);
            adminRepo = new AdminRepo(App.Database);
        }
        async void ExecuteLoginAsAdmin()
        {
            if (_login == adminRepo.GetAdmin().Result.Login && _password == adminRepo.GetAdmin().Result.Password) {
                await Application.Current.MainPage.Navigation.PushAsync(new CRUDMainPage());
            }
        }
    }
}
