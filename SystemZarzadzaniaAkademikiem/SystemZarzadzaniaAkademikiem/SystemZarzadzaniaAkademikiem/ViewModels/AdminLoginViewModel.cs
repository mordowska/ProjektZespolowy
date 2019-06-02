using System.Diagnostics;
using SystemZarzadzaniaAkademikiem.Services;
using SystemZarzadzaniaAkademikiem.Views;
using Xamarin.Forms;

namespace SystemZarzadzaniaAkademikiem.ViewModels
{
    public class AdminLoginViewModel : BaseViewModel
    {
        private readonly AdminRepo adminRepo;
        private string _login;
        private string _password;

        public AdminLoginViewModel()
        {
            Title = "Welcome to Admin Login Page.Please enter credentials below.";
            LoginAsAdmin = new Command(ExecuteLoginAsAdmin);
            adminRepo = new AdminRepo(App.Database);
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public Command LoginAsAdmin { get; set; }

        private async void ExecuteLoginAsAdmin()
        {
            if (_login == adminRepo.GetAdmin().Result.Login && _password == StringCipher.Decrypt(adminRepo.GetAdmin().Result.Password,adminRepo.GetAdmin().Result.Salt)) 
                await Application.Current.MainPage.Navigation.PushAsync(new CRUDMainPage());
        }
    }
}